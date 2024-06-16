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
    /// Lógica de interacción para ClienteView.xaml
    /// </summary>
    public partial class ClienteView : UserControl
    {
        public ClienteView()
        {
            InitializeComponent();
        }









        /*private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                var cliente = new ClienteModel
                {
                    NomCliente = NombreTextBox.Text,
                    DNI = DNITextBox.Text,
                    Telefono1 = int.Parse(TelefonoTextBox.Text),
                    CodPostal = int.Parse(CodigoPostalTextBox.Text),
                    Ciudad = "x",
                    Comentario = "y",
                    ProvinciaId = 1, 
                    Direccion = "s",
                    Email = "m",
                    Telefono2 = 234,
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();

                NombreTextBox.Text = "";
                DNITextBox.Text = "";
                TelefonoTextBox.Text = "";
                CodigoPostalTextBox.Text = "";
            }
        }*/
    }
}
