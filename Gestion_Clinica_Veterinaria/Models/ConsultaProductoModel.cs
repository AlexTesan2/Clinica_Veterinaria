using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Clinica_Veterinaria.Models
{
    public class ConsultaProductoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdConsultaProducto { get; set; }

        public int IdConsulta { get; set; }
        public ConsultaModel Consulta { get; set; }

        public int IdProducto { get; set; }
        public ProductoModel Producto { get; set; }
    }
}
