namespace BackEnd.Models;
public class PerfilViewModel
{
    public Estudiante Estudiante { get; set; }
    public IEnumerable<Evento> EventosInscritos { get; set; }
    
    [Required(ErrorMessage = "Por favor, seleccione una imagen.")]
    public IFormFile ImagenURL { get; set; }
        
}
