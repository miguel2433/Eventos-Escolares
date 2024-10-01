namespace BackEnd.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public required string ContrasenaLogin { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string UsernameLogin { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public required string CorreoLogin { get; set; }

    }
}