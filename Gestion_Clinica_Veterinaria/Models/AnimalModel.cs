using Gestion_Clinica_Veterinaria.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AnimalModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAnimal { get; set; }
    public int Chip { get; set; }
    public string NomAnimal { get; set; }
    public string Cliente { get; set; }
    public string Raza { get; set; }
    public string Especie { get; set; }
    public string Sexo { get; set; }
    public int Peso { get; set; }
    public string Tamanyo { get; set; }
    public DateTime FNac { get; set; }
    public int Edad { get; set; }
    public bool Peligroso { get; set; }
    public bool Esterilizado { get; set; }
    public bool Vivo { get; set; }
    public string TipoPelo { get; set; }
    public int NumPasaporte { get; set; }
    public string ColorOjos { get; set; }
    public string Comentario { get; set; }


    //[ForeignKey("IdRaza")]
    //public RazaModel Raza { get; set; }
    //public EspecieModel Especie { get; set; }

    //[ForeignKey("IdClienteDelAnimal")]
    //public ClienteModel ClienteDelAnimal { get; set; }
}
