namespace BackEnd.Models;

public class CrearEventoViewModel
{
    public Evento evento {get;set;}
    
    [Required]
    public IFormFile Imagen {get;set;}
}
