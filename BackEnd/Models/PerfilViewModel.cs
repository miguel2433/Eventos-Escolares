namespace BackEnd.Models;
public class PerfilViewModel
{
    public Estudiante estudiante { get; set; }
    
    [Required(ErrorMessage = "Por favor, seleccione una imagen.")]
    public IFormFile ImagenURL { get; set; }
        
}
