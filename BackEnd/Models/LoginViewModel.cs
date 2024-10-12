namespace BackEnd.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "La Contraseña es requerida.")]
        public required string ContrasenaLogin { get; set; }

        [Required(ErrorMessage = "El Username es requerido")]
        public required string UsernameLogin { get; set; }
        
        [Required(ErrorMessage = "El Correo es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public required string CorreoLogin { get; set; }

    }
}