using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Gestion_Clinica_Veterinaria.DB;
using Gestion_Clinica_Veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clinica_Veterinaria.Views
{
    /// <summary>
    /// Interaction logic for EditarConsultaView.xaml
    /// </summary>
    public partial class EditarConsultaView : UserControl
    {
        private ConsultaModel _consulta;
        private List<AnimalModel> animales;

        public EditarConsultaView(ConsultaModel consulta)
        {
            InitializeComponent();
            _consulta = consulta;
            DataContext = _consulta;
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

                _consulta.Animal = animalSeleccionado.NomAnimal;
                _consulta.Cliente = animalSeleccionado.Cliente;
                _consulta.Precio = string.IsNullOrWhiteSpace(PrecioTextBox.Text) ? 0 : int.Parse(PrecioTextBox.Text);
                _consulta.Procedimiento = string.IsNullOrWhiteSpace(ProcedimientoTextBox.Text) ? "" : ProcedimientoTextBox.Text;
                _consulta.Sintomas = string.IsNullOrWhiteSpace(SintomasTextBox.Text) ? "" : SintomasTextBox.Text;
                _consulta.TipoConsulta = TiposConsultaComboBox.SelectedValue?.ToString();

                context.Consultas.Update(_consulta);
                context.SaveChanges();

                MessageBox.Show("Consulta actualizada con éxito.");
                Window.GetWindow(this).Close();
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

        private void CargarAnimales()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                animales = context.Animales.ToList();
                AnimalesDataGrid.ItemsSource = animales;

                var animalSeleccionado = animales.FirstOrDefault(a => a.NomAnimal == _consulta.Animal && a.Cliente == _consulta.Cliente);
                if (animalSeleccionado != null)
                {
                    AnimalesDataGrid.SelectedItem = animalSeleccionado;
                }
            }
        }
    }
}
