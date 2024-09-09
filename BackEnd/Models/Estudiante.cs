namespace BackEnd.Models
{
    public class Estudiante
    {
        public int idEstudiante {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Nombre {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public  required string Apellido {get;set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public byte? Año {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public byte? Division {get;set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Correo { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Username { get; set; }
        public string ImageUrl {get;set;}
    }
}