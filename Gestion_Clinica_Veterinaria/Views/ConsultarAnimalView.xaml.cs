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
            //CargarEspecies();
        }

        private void CargarAnimales()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                //_animales = context.Animales.Include(a => a.Especie).Include(a => a.Raza).ToList();
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
                //BuscarEspecieComboBox.ItemsSource = context.Especies.ToList();
            }
        }

        private void BuscarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //FiltrarAnimales();
        }

        private void BuscarComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // FiltrarAnimales();
        }

        private void FiltrarAnimales()
        {
            var filtroNombre = BuscarNombreTextBox.Text.ToLower();

            var animalesFiltrados = _animales.Where(a =>
                (string.IsNullOrWhiteSpace(filtroNombre) || a.NomAnimal.ToLower().Contains(filtroNombre)) 
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
