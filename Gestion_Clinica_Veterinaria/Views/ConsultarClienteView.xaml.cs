using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_Clinica_Veterinaria.DB;
using Gestion_Clinica_Veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clinica_Veterinaria.Views
{
    public partial class ConsultarClienteView : UserControl
    {
        private List<ClienteModel> _clientes;

        public ConsultarClienteView()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                _clientes = context.Clientes.ToList();
                ClientesDataGrid.ItemsSource = _clientes;
            }
        }

        private void BuscarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtroNombre = BuscarNombreTextBox.Text.ToLower();
            var filtroDni = BuscarDniTextBox.Text.ToLower();
            
            var clientesFiltrados = _clientes.Where(c => 
                (string.IsNullOrWhiteSpace(filtroNombre) || c.NomCliente.ToLower().Contains(filtroNombre)) &&
                (string.IsNullOrWhiteSpace(filtroDni) || c.DNI.ToLower().Contains(filtroDni))
            ).ToList();
            
            ClientesDataGrid.ItemsSource = clientesFiltrados;
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var cliente = button.Tag as ClienteModel;
            if (cliente != null)
            {
                var editarClienteView = new EditarClienteView(cliente);
                var window = new Window
                {
                    Content = editarClienteView,
                    Title = "Editar Cliente",
                    SizeToContent = SizeToContent.WidthAndHeight
                };
                window.ShowDialog();
                CargarClientes();
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var cliente = button.Tag as ClienteModel;
            if (cliente != null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();
                }

                CargarClientes();
            }
        }
    }
}