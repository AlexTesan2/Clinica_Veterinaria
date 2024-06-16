using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Clinica_Veterinaria.Models
{
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        public string NomCliente { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public int Telefono1 { get; set; }
        public int Telefono2 { get; set; }

        //public ProvinciaModel ProvinciaDelUsuario { get; set; }
        public int ProvinciaId { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public int CodPostal { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Comentario { get; set; }

        [NotMapped]
        public List<int> ListaIdMascotasDelCliente { get; set; }
        public List<AnimalModel> ListaMascotasDelCliente { get; set; }
    }
}
