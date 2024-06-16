using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Gestion_Clinica_Veterinaria.DB;
using Gestion_Clinica_Veterinaria.Models;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Application = System.Windows.Application;

namespace Gestion_Clinica_Veterinaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            CrearBD();
        }



        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Para mover la ventana con el raton
            //DragMove();
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        
        private void pnlControlBar_MouseEnter_1(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimice_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximice_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

















        public static void CrearBD()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //var optionsBuilder = new DbContextOptionsBuilder<Context>();
            //optionsBuilder.UseSqlServer(connectionString);
            
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                if (context.Database.EnsureCreated())
                {
                    //TipoProductoModelo
                    var vacuna = new TipoProductoModelo { NomTipoProducto = "Vacuna" };
                    context.TipoProductos.Add(vacuna);
                    var medicamento = new TipoProductoModelo { NomTipoProducto = "Medicamento" };
                    context.TipoProductos.Add(medicamento);


                    //CapaModel
                    var capa1 = new CapaModel { NomCapa = "Pardo" };
                    var capa2 = new CapaModel { NomCapa = "Gris" };
                    var capa3 = new CapaModel { NomCapa = "Negro" };
                    var capa4 = new CapaModel { NomCapa = "Blanco" };
                    var capa5 = new CapaModel { NomCapa = "Marrón " };
                    var capa6 = new CapaModel { NomCapa = "Rojo" };
                    var capa7 = new CapaModel { NomCapa = "Naranja" };
                    var capa8 = new CapaModel { NomCapa = "Amarillo" };
                    context.Capas.Add(capa1);
                    context.Capas.Add(capa2);
                    context.Capas.Add(capa3);
                    context.Capas.Add(capa4);
                    context.Capas.Add(capa5);
                    context.Capas.Add(capa6);
                    context.Capas.Add(capa7);
                    context.Capas.Add(capa8);


                    // Provincias de España
                    var nombresProvincias = new List<string>
                    {
                        "Álava", "Albacete", "Alicante", "Almería", "Asturias", "Ávila", "Badajoz", "Baleares",
                        "Barcelona", "Burgos", "Cáceres", "Cádiz", "Cantabria", "Castellón", "Ciudad Real",
                        "Córdoba", "Cuenca", "Gerona", "Granada", "Guadalajara", "Guipúzcoa", "Huelva",
                        "Huesca", "Jaén", "La Coruña", "La Rioja", "Las Palmas", "León", "Lérida", "Lugo",
                        "Madrid", "Málaga", "Murcia", "Navarra", "Orense", "Palencia", "Pontevedra", "Salamanca",
                        "Segovia", "Sevilla", "Soria", "Tarragona", "Santa Cruz de Tenerife", "Teruel", "Toledo",
                        "Valencia", "Valladolid", "Vizcaya", "Zamora", "Zaragoza"
                    };
                    foreach (var nombreProvincia in nombresProvincias)
                    {
                        var provincia = new ProvinciaModel { NomProvincia = nombreProvincia };
                        context.Provincias.Add(provincia);
                    }


                    //TipoPelo
                    var corto = new TipoPeloModel { NomTipoPelo = "Corto" };
                    var largo = new TipoPeloModel { NomTipoPelo = "Largo" };
                    var semilargo = new TipoPeloModel { NomTipoPelo = "Semilargo" };
                    var liso = new TipoPeloModel { NomTipoPelo = "Liso" };
                    var rizado = new TipoPeloModel { NomTipoPelo = "Rizado" };
                    var duro = new TipoPeloModel { NomTipoPelo = "Duro" };
                    var doble = new TipoPeloModel { NomTipoPelo = "Doble" };
                    var sinMuda = new TipoPeloModel { NomTipoPelo = "Sin Muda" };
                    context.TipoPelos.Add(corto);
                    context.TipoPelos.Add(largo);
                    context.TipoPelos.Add(semilargo);
                    context.TipoPelos.Add(liso);
                    context.TipoPelos.Add(rizado);
                    context.TipoPelos.Add(duro);
                    context.TipoPelos.Add(doble);
                    context.TipoPelos.Add(sinMuda);


                    //Tipo Consulta
                    var visita = new TipoConsultaModel { NomTipoConsulta = "Visita" };
                    var operacion = new TipoConsultaModel { NomTipoConsulta = "Operacion" };
                    context.TipoConsultas.Add(visita);
                    context.TipoConsultas.Add(operacion);


                    //EspecieModel
                    var gato = new EspecieModel { NomEspecie = "Gato" };
                    var perro = new EspecieModel { NomEspecie = "Perro" };
                    var ave = new EspecieModel { NomEspecie = "Ave" };
                    var Roedor = new EspecieModel { NomEspecie = "Roedor" };
                    var Otro = new EspecieModel { NomEspecie = "Otro" };
                    context.Especies.Add(gato);
                    context.Especies.Add(perro);
                    context.Especies.Add(ave);
                    context.Especies.Add(Roedor);
                    context.Especies.Add(Otro);



                    //razaModel
                    // Lista de nombres de razas de gatos
                    var nombresRazasGatos = new List<string>
                    {
                        "Siamés", "Persa", "Maine Coon", "Bengala", "Sphynx", "Ragdoll", "Abisinio", "Birmano",
                        "British Shorthair", "Oriental Shorthair", "Scottish Fold", "Devon Rex", "Cornish Rex",
                        "Exótico de Pelo Corto", "Himalayo"
                    };
                    foreach (var nombreRaza in nombresRazasGatos)
                    {
                        var raza = new RazaModel { EspecieId = 1, NomRaza = nombreRaza };
                        context.Razas.Add(raza);
                    }


                    // Lista de nombres de razas de perros
                    var nombresRazasPerros = new List<string>
                    {
                        "Labrador Retriever", "Golden Retriever", "Pastor Alemán", "Bulldog", "Beagle", "Poodle", "Rottweiler", "Yorkshire Terrier",
                        "Boxer", "Dachshund", "Shih Tzu", "Schnauzer Miniatura", "Chihuahua", "Doberman", "Great Dane", "Siberian Husky",
                        "Pomeranian", "Bulldog Francés", "Cocker Spaniel", "Border Collie", "Pug", "Maltés", "Weimaraner", "Bichón Frisé",
                        "Chow Chow", "Akita Inu", "Dálmata", "Boston Terrier", "Shetland Sheepdog", "Pinscher Miniatura",
                        "Staffordshire Bull Terrier", "West Highland White Terrier", "San Bernardo", "Bloodhound", "Collie",
                        "American Pit Bull Terrier", "Bull Terrier", "Shar Pei", "Cane Corso", "Mastín Napolitano", "Vizsla", "Shiba Inu",
                        "Airedale Terrier", "Fox Terrier", "Whippet", "Rhodesian Ridgeback", "Papillon", "Samoyedo", "Galgo Español", "Irish Setter"
                    };
                    foreach (var nombreRaza in nombresRazasPerros)
                    {
                        var raza = new RazaModel { EspecieId = 2, NomRaza = nombreRaza };
                        context.Razas.Add(raza);
                    }

                    //Otros
                    var loro = new RazaModel { EspecieId = 3, NomRaza = "Loro" };
                    context.Razas.Add(loro);
                    var pajaro = new RazaModel { EspecieId = 3, NomRaza = "Pajaro" };
                    context.Razas.Add(pajaro);
                    var conejo = new RazaModel { EspecieId = 4, NomRaza = "Conejo" };
                    context.Razas.Add(conejo);
                    var Hammster = new RazaModel { EspecieId = 4, NomRaza = "Hammster" };
                    context.Razas.Add(Hammster);
                    var Uron = new RazaModel { EspecieId = 4, NomRaza = "Uron" };
                    context.Razas.Add(Uron);
                    var otro = new RazaModel { EspecieId = 5, NomRaza = "Otro" };
                    context.Razas.Add(otro);
                        
                        
                        
                        
                    context.SaveChanges();

                }
            }
        }

        private void pnlControlBar_MouseEnter_1(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void pnlControlBar_MouseEnter_2(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}/*
  si var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;=
connectionString = "Data Source=DESKTOP-1DSINV3;Initial Catalog=GestionVeterinaria;Integrated Security=True;TrustServerCertificate=true"
var optionsBuilder = new DbContextOptionsBuilder<Context>();  = optionsBuilder = {Microsoft.EntityFrameworkCore.DbContextOptionsBuilder`1[Gestion_Clinica_Veterinaria.DB.Context]}
optionsBuilder.UseSqlServer(connectionString);

using (var context = new Context(optionsBuilder.Options)) = context = {Gestion_Clinica_Veterinaria.DB.Context}

  
  */