using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Clinica_Veterinaria.Models
{
    public class RazaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRaza { get; set; }
        public string NomRaza { get; set; }
        public int EspecieId { get; set; }
        public ICollection<AnimalModel> Animales { get; set; }
    }
}
