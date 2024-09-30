namespace BackEnd.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public required string Contrasena { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Username { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public required string Correo { get; set; }

    }
}