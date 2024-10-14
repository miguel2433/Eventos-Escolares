namespace BackEnd.Models;    

public class EventoCompletoViewModel
{
    public Evento Evento { get; set;}
    public Estudiante Estudiante { get; set; }
    public List<Estudiante>? Estudiantes { get; set; }
}


