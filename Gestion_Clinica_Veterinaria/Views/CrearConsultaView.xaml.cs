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
    /// Lógica de interacción para CrearConsultaView.xaml
    /// </summary>
    public partial class CrearConsultaView : UserControl
    {
        public CrearConsultaView()
        {
            InitializeComponent();
            CargarTiposConsulta();
            CargarAnimales();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                var animalSeleccionado = (AnimalModel)AnimalesDataGrid.SelectedItem;
                if (animalSeleccionado == null)
                {
                    MessageBox.Show("Por favor, selecciona un animal.");
                    return;
                }
                string nomAnimal = animalSeleccionado.NomAnimal;
                string nomCliente = animalSeleccionado.Cliente;
                int numAnimal = animalSeleccionado.IdAnimal;
                var Consulta = new ConsultaModel
                {
                    Precio = string.IsNullOrWhiteSpace(PrecioTextBox.Text) ? 0 : int.Parse(PrecioTextBox.Text),
                    Procedimiento = string.IsNullOrWhiteSpace(ProcedimientoTextBox.Text) ? "" : ProcedimientoTextBox.Text,
                    Sintomas = string.IsNullOrWhiteSpace(SintomasTextBox.Text) ? "" : SintomasTextBox.Text,
                    Fecha = DateTime.Now,
                    Comentario = "",
                    TipoConsulta = TiposConsultaComboBox.SelectedValue?.ToString(),
                    Animal = nomAnimal,
                    Cliente = nomCliente,
                    
                };
                context.Consultas.Add(Consulta);
                context.SaveChanges();

                
                PrecioTextBox.Text = "";
                ProcedimientoTextBox.Text = "";
                SintomasTextBox.Text = "";
            }
        }


        private void CargarTiposConsulta()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                TiposConsultaComboBox.ItemsSource = context.TipoConsultas.ToList();
            }
        }

        private List<AnimalModel> animales;
        private void CargarAnimales()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                animales = context.Animales.ToList();
                AnimalesDataGrid.ItemsSource = animales;
            }
        }

        private void BuscarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtroNombre = BuscarNombreTextBox.Text.ToLower();

            var animalesFiltrados = animales.Where(a =>
                string.IsNullOrWhiteSpace(filtroNombre)
                || a.NomAnimal.ToLower().Contains(filtroNombre)
                || a.Cliente.ToLower().Contains(filtroNombre)).ToList();

            AnimalesDataGrid.ItemsSource = animalesFiltrados;
        }
    }
}
