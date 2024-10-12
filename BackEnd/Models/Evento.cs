namespace BackEnd.Models
{
    public class Evento
    {
        public int idEvento { get; set; }
        public required string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public required string Ubicacion { get; set; }
        public required string Descripcion { get; set; }
        public string? ImagenUrl { get; set; }
    }
}