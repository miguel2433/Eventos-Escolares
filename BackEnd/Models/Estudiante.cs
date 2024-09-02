using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Estudiante
    {
        public int idEstudiante {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Nombre {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public string Apellido {get;set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public byte? Año {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public byte? Division {get;set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Correo { get; set; }

        public string ImageUrl {get;set;}
    }
}