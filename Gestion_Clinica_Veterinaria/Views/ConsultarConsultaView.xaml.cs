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
    /// <summary>
    /// Lógica de interacción para ConsultarConsultaView.xaml
    /// </summary>
    public partial class ConsultarConsultaView : UserControl
    {
        private List<ConsultaModel> consultas;
        public ConsultarConsultaView()
        {
            InitializeComponent();
            CargarConsultas();
        }

        private void CargarConsultas()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                consultas = context.Consultas.ToList();
                ConsultasDataGrid.ItemsSource = consultas;
            }
        }

        private void BuscarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtroCliente = BuscarClienteTextBox.Text.ToLower();
            var filtroMascota = BuscarMascotaTextBox.Text.ToLower();

            var consultasFiltradas = consultas.Where(c =>
                (string.IsNullOrWhiteSpace(filtroCliente) || c.Cliente.ToLower().Contains(filtroCliente)) &&
                (string.IsNullOrWhiteSpace(filtroMascota) || c.Animal.ToLower().Contains(filtroMascota))
            ).ToList();

            ConsultasDataGrid.ItemsSource = consultasFiltradas;
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var consulta = button.Tag as ConsultaModel;
            if (consulta != null)
            {
                var EditarConsultaView = new EditarConsultaView(consulta);
                var window = new Window
                {
                    Content = EditarConsultaView,
                    Title = "Editar Consulta",
                    SizeToContent = SizeToContent.WidthAndHeight
                };
                window.ShowDialog();
                CargarConsultas();
            }
        }


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var consultaAEliminar = button.Tag as ConsultaModel;
            if (consultaAEliminar != null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    context.Consultas.Remove(consultaAEliminar);
                    context.SaveChanges();
                }

                CargarConsultas();
            }
        }
    }
}
