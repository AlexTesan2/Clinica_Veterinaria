using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Gestion_Clinica_Veterinaria.DB;
using Gestion_Clinica_Veterinaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Gestion_Clinica_Veterinaria.Views
{
    public partial class CrearAnimalView : UserControl
    {
        public CrearAnimalView()
        {
            InitializeComponent();
            CargarPelos();
            CargarEspecies();
            CargarRazas();
            CargarClientes();
        }

        private void CargarPelos()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                PelosComboBox.ItemsSource = context.TipoPelos.ToList();
            }
        }

        private void CargarEspecies()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                EspeciesComboBox.ItemsSource = context.Especies.ToList();
            }

            EspeciesComboBox.SelectionChanged += EspeciesComboBox_SelectionChanged;
        }

        private void CargarRazas()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                RazasComboBox.ItemsSource = context.Razas.ToList();
            }
        }

        private void EspeciesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var especieSeleccionada = EspeciesComboBox.SelectedItem as EspecieModel;

            if (especieSeleccionada != null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    var razas = context.Razas.Where(r => r.EspecieId == especieSeleccionada.Id_Especie).ToList();
                    RazasComboBox.ItemsSource = razas;
                }
            }
            else
            {
                CargarRazas();
            }
        }

        private void CargarClientes()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var nombresClientes = context.Clientes.Select(c => c.NomCliente).ToList();
                ClientesComboBox.ItemsSource = nombresClientes;
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    var especieSeleccionada = EspeciesComboBox.SelectedItem as EspecieModel;
                    var razaSeleccionada = RazasComboBox.SelectedItem as RazaModel;
                    var tipoPeloSeleccionado = PelosComboBox.SelectedItem as TipoPeloModel;
                    string nomRaza = razaSeleccionada?.NomRaza;
                    string nomEspecie = especieSeleccionada?.NomEspecie;
                    string pelo = tipoPeloSeleccionado?.NomTipoPelo;

                    int peso = 0;
                    if (!int.TryParse(PesoTextBox.Text, out peso))
                    {
                        MessageBox.Show("El peso debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    int chip = 0;
                    if (!int.TryParse(ChipTextBox.Text, out chip))
                    {
                        MessageBox.Show("El chip debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    DateTime fechaNacimiento = FechaNacimientoDatePicker.SelectedDate ?? DateTime.Now;

                    var animal = new AnimalModel
                    {
                        NomAnimal = NombreTextBox.Text,
                        Cliente = ClientesComboBox.Text,
                        Raza = nomRaza,
                        Especie = nomEspecie,
                        Sexo = (SexoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "",
                        Peso = peso,
                        Tamanyo = TamyoTextBox.Text,
                        FNac = fechaNacimiento,
                        Edad = CalcularEdad(fechaNacimiento),
                        Peligroso = SiPeligroRadioButton.IsChecked ?? false,
                        Esterilizado = SiEsterilizadoRadioButton.IsChecked ?? false,
                        Vivo = true,
                        TipoPelo = pelo,
                        NumPasaporte = string.IsNullOrWhiteSpace(PasaporteTextBox.Text) ? 0 : int.Parse(PasaporteTextBox.Text),
                        ColorOjos = ColorOjosTextBox.Text,
                        Comentario = ComentarioTextBox.Text,
                        Chip = chip,
                    };

                    context.Animales.Add(animal);
                    context.SaveChanges();

                    MessageBox.Show("Animal guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el animal: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-edad)) edad--;

            return edad;
        }

        private void LimpiarCampos()
        {
            NombreTextBox.Text = "";
            ClientesComboBox.SelectedIndex = -1;
            EspeciesComboBox.SelectedIndex = -1;
            RazasComboBox.SelectedIndex = -1;
            PelosComboBox.SelectedIndex = -1;
            SexoComboBox.SelectedIndex = -1;
            PesoTextBox.Text = "";
            TamyoTextBox.Text = "";
            FechaNacimientoDatePicker.SelectedDate = null;
            SiPeligroRadioButton.IsChecked = false;
            NoPeligroRadioButton.IsChecked = true;
            SiEsterilizadoRadioButton.IsChecked = false;
            NoEsterilizadoRadioButton.IsChecked = true;
            ChipTextBox.Text = "";
            ColorOjosTextBox.Text = "";
            ComentarioTextBox.Text = "";
            PasaporteTextBox.Text = "";
        }
    }
}
