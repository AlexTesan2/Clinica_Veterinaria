using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Clinica_Veterinaria.Models
{
    public class AnimalModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnimal { get; set; }
        public int Chip { get; set; }
        public string NomAnimal { get; set; }
        public ClienteModel ClienteDelAnimal { get; set; }
        public int IdClienteDelAnimal { get; set; }
        public int IdRaza { get; set; }
        public string Sexo { get; set; }
        public int Peso { get; set; }
        public string Tamanyo { get; set; }
        public DateTime FNac { get; set; }
        public int Edad { get; set; }
        public bool Peligroso { get; set; }
        public bool Esterilizado { get; set; }
        public bool Vivo { get; set; }
        public int IdTipoPelo { get; set; }
        public int NumPasaporte { get; set; }
        public string ColorOjos { get; set; }
        public string Comentario { get; set;}

    }
}
