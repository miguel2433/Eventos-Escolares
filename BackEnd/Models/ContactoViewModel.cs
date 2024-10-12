namespace BackEnd.Models
{
    public class ContactoViewModel
    {
        public int idUsuario {get;set;}
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Nombre {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string  Apellido {get;set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int? Año {get; set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int? Division {get;set;}

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string Correo { get; set; }
    }
}