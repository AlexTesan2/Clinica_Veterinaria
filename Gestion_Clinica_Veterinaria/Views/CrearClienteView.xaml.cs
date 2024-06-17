using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gestion_Clinica_Veterinaria.Views
{
    public partial class CrearClienteView : UserControl
    {
        public CrearClienteView()
        {
            InitializeComponent();
            CargarProvincias();
        }

        private void CargarProvincias()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                ProvinciaComboBox.ItemsSource = context.Provincias.ToList();
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {

                context.Database.EnsureCreated();
                var cliente = new ClienteModel
                {
                    NomCliente = string.IsNullOrWhiteSpace(NombreTextBox.Text) ? "" : NombreTextBox.Text,
                    DNI = string.IsNullOrWhiteSpace(DNITextBox.Text) ? "" : DNITextBox.Text,
                    Email = string.IsNullOrWhiteSpace(EmailTextBox.Text) ? "" : EmailTextBox.Text,
                    Telefono1 = string.IsNullOrWhiteSpace(Telefono1TextBox.Text) ? 0 : int.Parse(Telefono1TextBox.Text),
                    Telefono2 = string.IsNullOrWhiteSpace(Telefono2TextBox.Text) ? 0 : int.Parse(Telefono2TextBox.Text),
                    CodPostal = string.IsNullOrWhiteSpace(CodigoPostalTextBox.Text) ? 0 : int.Parse(CodigoPostalTextBox.Text),
                    Ciudad = string.IsNullOrWhiteSpace(CiudadTextBox.Text) ? "" : CiudadTextBox.Text,
                    Provincia = ProvinciaComboBox.SelectedValue?.ToString(),
                    Direccion = string.IsNullOrWhiteSpace(DireccionTextBox.Text) ? "" : DireccionTextBox.Text,
                    FechaAlta = DateTime.Now,
                    Comentario = ""
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();

                // Limpiar los campos después de guardar
                NombreTextBox.Text = "";
                DNITextBox.Text = "";
                EmailTextBox.Text = "";
                Telefono1TextBox.Text = "";
                Telefono2TextBox.Text = "";
                CodigoPostalTextBox.Text = "";
                CiudadTextBox.Text = "";
                DireccionTextBox.Text = "";
                ProvinciaComboBox.SelectedIndex = -1;
            }
        }

        private void Num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !onlyNumer(e.Text);
        }

        private static readonly Regex regexNum = new Regex("[^0-9]+");

        private static bool onlyNumer(string text)
        {
            return !regexNum.IsMatch(text);
        }
    }
}
