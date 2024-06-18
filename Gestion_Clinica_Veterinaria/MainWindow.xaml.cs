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
using Microsoft.VisualBasic;

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
            //Inento no logrado de hacer una conexion BD mas limpia
            //var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //var optionsBuilder = new DbContextOptionsBuilder<Context>();
            //optionsBuilder.UseSqlServer(connectionString);
            
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1DSINV3;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                if (context.Database.EnsureCreated())
                {
                    //DATOS POR DEFECTO A INSERTAR EN LA BD AL CREARSE

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

                    //Clientes
                    var desarrollador = new ClienteModel
                    {
                        NomCliente = "Alex",
                        Ciudad = "Zaragoza",
                        CodPostal = 5004,
                        Comentario = "Soy el programador",
                        Direccion = "Calle 2",
                        DNI = "0724545",
                        Email = "alex@gmail.com",
                        Telefono1=12345,
                        Telefono2=67890,
                        Provincia = "Zaragoza",
                        FechaAlta = DateAndTime.Today
                    };
                    var player1 = new ClienteModel
                    {
                        NomCliente = "Cristina",
                        Ciudad = "Zaragoza",
                        CodPostal = 5008,
                        Comentario = "",
                        Direccion = "Plaza ...",
                        DNI = "0724545",
                        Email = "c@email.com",
                        Telefono1 = 1565,
                        Telefono2 = 89090,
                        Provincia = "Zaragoza",
                        FechaAlta = DateAndTime.Today
                    };
                    var player2 = new ClienteModel
                    {
                        NomCliente = "Laura",
                        Ciudad = "Murcia",
                        CodPostal = 5022,
                        Comentario = "",
                        Direccion = "Muy lejos",
                        DNI = "45678",
                        Email = "lau@gmail.com",
                        Telefono1 = 1565,
                        Telefono2 = 89090,
                        Provincia = "Murcia",
                        FechaAlta = DateAndTime.Today
                    };
                    var player3 = new ClienteModel
                    {
                        NomCliente = "Carlos",
                        Ciudad = "Toledo",
                        CodPostal = 5022,
                        Comentario = "",
                        Direccion = "Casa de ..",
                        DNI = "455678",
                        Email = "carl@gmail.com",
                        Telefono1 = 14565,
                        Telefono2 = 869090,
                        Provincia = "Toledo",
                        FechaAlta = DateAndTime.Today
                    };

                    var player4 = new ClienteModel
                    {
                        NomCliente = "Rocio",
                        Ciudad = "Italia",
                        CodPostal = 5022,
                        Comentario = "",
                        Direccion = "Muy lejos",
                        DNI = "45678",
                        Email = "lau@gmail.com",
                        Telefono1 = 1565,
                        Telefono2 = 89090,
                        Provincia = "Madrid",
                        FechaAlta = DateAndTime.Today
                    };
                    var player5 = new ClienteModel
                    {
                        NomCliente = "Adrian",
                        Ciudad = "Samper",
                        CodPostal = 5022,
                        Comentario = "",
                        Direccion = "Por abajo",
                        DNI = "45678",
                        Email = "adri@gmail.com",
                        Telefono1 = 1565,
                        Telefono2 = 89090,
                        Provincia = "Teruel",
                        FechaAlta = DateAndTime.Today
                    };
                    context.Clientes.Add(desarrollador);
                    context.Clientes.Add(player1);
                    context.Clientes.Add(player2);
                    context.Clientes.Add(player3); 
                    context.Clientes.Add(player4);
                    context.Clientes.Add(player5);



                    //Productos
                    var producto1 = new ProductoModel
                    {
                        NomProducto = "Amoxicillina",
                        IdTipoProducto = 2, 
                        NumLote = 55000,
                        Comentario = "Pastilla"
                    };
                    var producto2 = new ProductoModel
                    {
                        NomProducto = "Vacuna Rabia",
                        IdTipoProducto = 1,
                        NumLote = 65000,
                        Comentario = "Inyeccion intravenosa"
                    }; 
                    var producto3 = new ProductoModel
                    {
                        NomProducto = "Vacuna Leishmania",
                        IdTipoProducto = 1,
                        NumLote = 2500,
                        Comentario = "Inyeccion intravenosa"
                    };
                    var producto4 = new ProductoModel
                    {
                        NomProducto = "Vacuna Hepatitis",
                        IdTipoProducto = 1,
                        NumLote = 2500,
                        Comentario = "Inyeccion intravenosa"
                    };
                    var producto5 = new ProductoModel
                    {
                        NomProducto = "Ampicilina",
                        IdTipoProducto = 2,
                        NumLote = 75000,
                        Comentario = "Pastilla2"
                    };

                    context.SaveChanges();


                    var animal1 = new AnimalModel
                    {
                        Especie = "Gato",
                        Raza = "Persa",
                        ColorOjos = "verdes",
                        Chip = 555,
                        Comentario = "",
                        Edad = 3,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Muchi",
                        TipoPelo = "Rizado",
                        NumPasaporte = 4567,
                        Peso = 5,
                        Sexo = "Macho",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Alex",

                    };
                    var animal2 = new AnimalModel
                    {
                        Especie = "Perro",
                        Raza= "Golden Retriever",
                        ColorOjos = "azules",
                        Chip = 645,
                        Comentario = "",
                        Edad = 5,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Laica",
                        TipoPelo = "Rizado",
                        NumPasaporte = 4569,
                        Peso = 5,
                        Sexo = "Hembra",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Laura",
                    };
                    var animal3 = new AnimalModel
                    {
                        Especie = "Gato",
                        Raza = "Himalayo",
                        ColorOjos = "rojos",
                        Chip = 972,
                        Comentario = "",
                        Edad = 3,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Paritas",
                        TipoPelo = "Corto",
                        NumPasaporte = 4567,
                        Peso = 5,
                        Sexo = "Macho",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Laura",
                    };
                    var animal4 = new AnimalModel
                    {
                        Especie = "Gato",
                        Raza = "Bengala",
                        ColorOjos = "verdes",
                        Chip = 972,
                        Comentario = "",
                        Edad = 3,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Superman",
                        TipoPelo = "Corto",
                        NumPasaporte = 4567,
                        Peso = 5,
                        Sexo = "Macho",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Rocio",
                    };
                    var animal5 = new AnimalModel
                    {
                        Especie = "Perro",
                        Raza = "Pug",
                        ColorOjos = "marrones",
                        Chip = 972,
                        Comentario = "",
                        Edad = 3,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Ralf",
                        TipoPelo = "Duro",
                        NumPasaporte = 4567,
                        Peso = 5,
                        Sexo = "Macho",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Alex",
                    };
                    var animal6 = new AnimalModel
                    {
                        Especie = "Perro",
                        Raza = "Dálmata",
                        ColorOjos = "azules",
                        Chip = 972,
                        Comentario = "",
                        Edad = 3,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Dalmata",
                        TipoPelo = "Semilargo",
                        NumPasaporte = 4567,
                        Peso = 5,
                        Sexo = "Macho",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Adrian",
                    };
                    var animal7 = new AnimalModel
                    {
                        Especie = "Perro",
                        Raza = "Pastor Alemán",
                        ColorOjos = "verdes",
                        Chip = 972,
                        Comentario = "",
                        Edad = 3,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Libre",
                        TipoPelo = "Doble",
                        NumPasaporte = 4567,
                        Peso = 5,
                        Sexo = "Macho",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Carlos",
                    };
                    var animal8 = new AnimalModel
                    {
                        Especie = "Perro",
                        Raza = "Bulldog Francés",
                        ColorOjos = "verdes",
                        Chip = 97342,
                        Comentario = "",
                        Edad = 3,
                        Esterilizado = true,
                        Peligroso = false,
                        NomAnimal = "Rufus",
                        TipoPelo = "Semilargo",
                        NumPasaporte = 4567,
                        Peso = 5,
                        Sexo = "Hembra",
                        Vivo = true,
                        Tamanyo = "normal",
                        Cliente = "Rocio",
                    };
                    context.Animales.Add(animal3);
                    context.Animales.Add(animal2);
                    context.Animales.Add(animal1);
                    context.Animales.Add(animal4);
                    context.Animales.Add(animal5);
                    context.Animales.Add(animal6);
                    context.Animales.Add(animal7);
                    context.Animales.Add(animal8);


                    var consulta1 = new ConsultaModel
                    {
                        Animal = "Laica",
                        Cliente = "Laura",
                        Comentario = "",
                        Fecha = DateAndTime.Today,
                        Precio = 55,
                        Procedimiento = "Darle unas pastillas",
                        Sintomas = "Mareos",
                        TipoConsulta = "Visita",
                    };
                    var consulta2 = new ConsultaModel
                    {
                        Animal = "Superman",
                        Cliente = "Rocio",
                        Comentario = "",
                        Fecha = DateAndTime.Today,
                        Precio = 55,
                        Procedimiento = "Colarle el pelo",
                        Sintomas = "Pelo largo",
                        TipoConsulta = "Visita",
                    }
                    ; var consulta3 = new ConsultaModel
                    {
                        Animal = "Laica",
                        Cliente = "Laura",
                        Comentario = "",
                        Fecha = DateAndTime.Today,
                        Precio = 55,
                        Procedimiento = "bla bla bla",
                        Sintomas = "Mareos",
                        TipoConsulta = "Visita",
                    };
                    var consulta4 = new ConsultaModel
                    {
                        Animal = "Dalmata",
                        Cliente = "Adrian",
                        Comentario = "",
                        Fecha = DateAndTime.Today,
                        Precio = 55,
                        Procedimiento = "",
                        Sintomas = "",
                        TipoConsulta = "Operacion",
                    };
                    var consulta5 = new ConsultaModel
                    {
                        Animal = "Ralf",
                        Cliente = "Alex",
                        Comentario = "",
                        Fecha = DateAndTime.Today,
                        Precio = 55,
                        Procedimiento = "Antibionticos",
                        Sintomas = "Picadura de serpiente",
                        TipoConsulta = "Visita",
                    };
                    
                    context.Consultas.Add( consulta1 );
                    context.Consultas.Add(consulta2);
                    context.Consultas.Add(consulta3);
                    context.Consultas.Add(consulta4);
                    context.Consultas.Add(consulta5);


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
}