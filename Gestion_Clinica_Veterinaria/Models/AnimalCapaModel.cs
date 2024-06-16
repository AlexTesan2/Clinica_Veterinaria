using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Clinica_Veterinaria.Models
{
    public class AnimalCapaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnimalCapa { get; set; }

        public int IdAnimal { get; set; }
        public AnimalModel Animal { get; set; }

        public int IdCapa { get; set; }
        public CapaModel Capa { get; set; }
    }
}
