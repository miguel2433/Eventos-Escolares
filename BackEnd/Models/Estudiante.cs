namespace BackEnd.Models
{
    public class Estudiante
    {
        public int idEstudiante {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Nombre {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public  required string Apellido {get;set;}

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 6, ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
        public int? Año { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 10, ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
        public int? Division { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Correo { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Username { get; set; }
        
        public string ImageUrl {get;set;} = "ImageUser";

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Contraseña {get;set;}


        [HiddenInput(DisplayValue = false)]
        public int? __Invariant { get; private set; }
    }
}