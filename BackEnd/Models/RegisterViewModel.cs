using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class RegisterViewModel
    {
         public int idEstudiante { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 6, ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
        public int? Anio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 10, ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
        public int? Division { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Username { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public required string Contrasena { get; set; }
    
        [Required(ErrorMessage = "La confirmación de la contraseña es obligatoria.")]
        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        public string? Repetir { get; set; } // Asegúrate de que sea una propiedad
    }
}
