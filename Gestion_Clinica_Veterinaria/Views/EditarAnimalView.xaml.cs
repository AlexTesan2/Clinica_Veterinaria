using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Gestion_Clinica_Veterinaria.DB;
using Gestion_Clinica_Veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clinica_Veterinaria.Views
{
    public partial class EditarAnimalView : UserControl
    {
        private AnimalModel _animal;

        public EditarAnimalView(AnimalModel animal)
        {
            InitializeComponent();
            _animal = animal;
            CargarDatos();
            CargarPelos();
            CargarEspecies();
            CargarRazas();
            CargarClientes();
        }

        private void CargarDatos()
        {
            NombreTextBox.Text = _animal.NomAnimal;
            ColorOjosTextBox.Text = _animal.ColorOjos;
            ChipTextBox.Text = _animal.Chip.ToString();
            PasaporteTextBox.Text = _animal.NumPasaporte.ToString();
            PesoTextBox.Text = _animal.Peso.ToString();
            TamyoTextBox.Text = _animal.Tamanyo;
            FechaNacimientoDatePicker.SelectedDate = _animal.FNac;
            ComentarioTextBox.Text = _animal.Comentario;

            if (_animal.Esterilizado == true) { SiEsterilizadoRadioButton.IsChecked = true; }
            else { NoEsterilizadoRadioButton.IsChecked = true; }

            if (_animal.Peligroso == true) { SiPeligroRadioButton.IsChecked = true; }
            else { NoPeligroRadioButton.IsChecked = true; }

            SexoComboBox.SelectedValue = _animal.Sexo;
            EspeciesComboBox.SelectedValue = _animal.Especie;
            RazasComboBox.SelectedValue = _animal.Raza;
            ClientesComboBox.SelectedValue = _animal.Cliente;
            PelosComboBox.SelectedValue = _animal.TipoPelo;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var animalActualizar = context.Animales.FirstOrDefault(a => a.IdAnimal == _animal.IdAnimal);
                if (animalActualizar != null)
                {
                    animalActualizar.NomAnimal = NombreTextBox.Text;
                    animalActualizar.Especie = EspeciesComboBox.SelectedValue?.ToString();
                    animalActualizar.Raza = RazasComboBox.SelectedValue?.ToString();
                    animalActualizar.Sexo = SexoComboBox.Text;
                    animalActualizar.TipoPelo = PelosComboBox.SelectedValue?.ToString();
                    animalActualizar.ColorOjos = ColorOjosTextBox.Text;
                    animalActualizar.Cliente = ClientesComboBox.SelectedValue?.ToString();
                    animalActualizar.Chip = Convert.ToInt32(ChipTextBox.Text);
                    animalActualizar.NumPasaporte = Convert.ToInt32(PasaporteTextBox.Text);
                    animalActualizar.Peso = Convert.ToInt32(PesoTextBox.Text);
                    animalActualizar.Tamanyo = TamyoTextBox.Text;
                    animalActualizar.FNac = FechaNacimientoDatePicker.SelectedDate.Value;
                    animalActualizar.Peligroso = SiPeligroRadioButton.IsChecked == true;
                    animalActualizar.Esterilizado = SiEsterilizadoRadioButton.IsChecked == true;
                    animalActualizar.Comentario = ComentarioTextBox.Text;

                    context.SaveChanges();
                    MessageBox.Show("Animal actualizado correctamente.");
                    Window.GetWindow(this).Close();
                }
            }
        }

        private void CargarPelos()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var pelos = context.TipoPelos.ToList();
                PelosComboBox.ItemsSource = pelos;
            }
        }

        private void CargarEspecies()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var especies = context.Especies.ToList();
                EspeciesComboBox.ItemsSource = especies;
            }
        }

        private void CargarRazas()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var razas = context.Razas.ToList();
                RazasComboBox.ItemsSource = razas;
            }
        }

        private void CargarClientes()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var clientes = context.Clientes.ToList();
                ClientesComboBox.ItemsSource = clientes;
            }
        }
    }
}
