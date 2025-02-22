﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Clinica_Veterinaria.Models
{
    public class ConsultaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsulta { get; set; }
        public string Animal { get; set; }
        public string Cliente { get; set; }
        public string TipoConsulta { get; set; }
        public DateTime Fecha { get; set; }
        public string Sintomas { get; set; }
        public string Procedimiento { get; set; }
        public string Comentario { get; set; }
        public int Precio { get; set;}
    }
}
