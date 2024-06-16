using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Clinica_Veterinaria.Models
{
    public class ProductoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string NomProducto { get; set; }
        public int NumLote { get; set; }
        public DateTime FCaducidad { get; set; }
        public int IdTipoProducto { get; set; }
        public string Comentario { get; set; }
    }
}
