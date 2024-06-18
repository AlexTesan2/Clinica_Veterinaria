using System.Windows;
using System.Windows.Controls;
using Gestion_Clinica_Veterinaria.DB;
using Gestion_Clinica_Veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Clinica_Veterinaria.Views
{
    public partial class EditarClienteView : UserControl
    {
        private ClienteModel _cliente;
        private List<ProvinciaModel> _provincias;

        public EditarClienteView(ClienteModel cliente)
        {
            InitializeComponent();
            CargarProvincias();
            _cliente = cliente;
            CargarDatos();
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
        private void CargarDatos()
        {
            NombreTextBox.Text = _cliente.NomCliente;
            DNITextBox.Text = _cliente.DNI;
            EmailTextBox.Text = _cliente.Email;
            Telefono1TextBox.Text = _cliente.Telefono1.ToString();
            Telefono2TextBox.Text = _cliente.Telefono2.ToString();
            CodigoPostalTextBox.Text = _cliente.CodPostal.ToString();
            CiudadTextBox.Text = _cliente.Ciudad;
            DireccionTextBox.Text = _cliente.Direccion;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                _provincias = context.Provincias.ToList();
                ProvinciaComboBox.ItemsSource = _provincias;
                ProvinciaComboBox.DisplayMemberPath = "NomProvincia";
                ProvinciaComboBox.SelectedValuePath = "NomProvincia";

                var provinciaSeleccionada = _provincias.FirstOrDefault(p => p.NomProvincia == _cliente.Provincia);
                if (provinciaSeleccionada != null)
                {
                    ProvinciaComboBox.SelectedValue = provinciaSeleccionada.NomProvincia;
                }
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            _cliente.NomCliente = NombreTextBox.Text;
            _cliente.DNI = DNITextBox.Text;
            _cliente.Email = EmailTextBox.Text;
            _cliente.Telefono1 = int.Parse(Telefono1TextBox.Text);
            _cliente.Telefono2 = int.Parse(Telefono2TextBox.Text);
            _cliente.CodPostal = int.Parse(CodigoPostalTextBox.Text);
            _cliente.Provincia = ProvinciaComboBox.SelectedValue?.ToString();
            _cliente.Ciudad = CiudadTextBox.Text;
            _cliente.Direccion = DireccionTextBox.Text;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                context.Clientes.Update(_cliente);
                context.SaveChanges();
            }

            MessageBox.Show("Cliente actualizado con éxito", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            Window.GetWindow(this).Close();
        }
    }
}
