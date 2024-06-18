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
    public partial class ConsultarAnimalView : UserControl
    {
        private List<AnimalModel> _animales;

        public ConsultarAnimalView()
        {
            InitializeComponent();
            CargarAnimales();
            CargarEspecies();
            EspeciesComboBox.SelectionChanged += EspeciesComboBox_SelectionChanged;
            RazasComboBox.SelectionChanged += RazasComboBox_SelectionChanged;
            BuscarNombreTextBox.TextChanged += BuscarTextBox_TextChanged;
        }

        private void CargarAnimales()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                _animales = context.Animales.ToList();
                AnimalesDataGrid.ItemsSource = _animales;
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
                CargarAnimales();
            }

            FiltrarAnimales();
        }

        public void RazasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FiltrarAnimales();
        }

        private void BuscarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrarAnimales();
        }

        private void FiltrarAnimales()
        {
            var filtroNombre = BuscarNombreTextBox.Text.ToLower();
            var especieSeleccionada = EspeciesComboBox.SelectedItem as EspecieModel;
            var razaSeleccionada = RazasComboBox.SelectedItem as RazaModel;

            var animalesFiltrados = _animales.Where(a =>
                (string.IsNullOrWhiteSpace(filtroNombre) || a.NomAnimal.ToLower().Contains(filtroNombre)) &&
                (especieSeleccionada == null || a.Especie == especieSeleccionada.NomEspecie) &&
                (razaSeleccionada == null || a.Raza == razaSeleccionada.NomRaza)
            ).ToList();

            AnimalesDataGrid.ItemsSource = animalesFiltrados;
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var animal = button.Tag as AnimalModel;
            if (animal != null)
            {
                var editarAnimalView = new EditarAnimalView(animal);
                var window = new Window
                {
                    Content = editarAnimalView,
                    Title = "Editar Animal",
                    SizeToContent = SizeToContent.WidthAndHeight
                };
                window.ShowDialog();
                CargarAnimales();
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var animal = button.Tag as AnimalModel;
            if (animal != null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    context.Animales.Remove(animal);
                    context.SaveChanges();
                }

                CargarAnimales();
            }
        }
    }
}
