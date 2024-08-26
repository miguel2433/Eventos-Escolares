
namespace BackEnd.Models
{
    public class Eventos
    {
        public int idEventos {get; set;}

        public required string Nombre {get; set;}

        public DateTime Fecha {get; set;}

        public required string Ubicacion {get; set;}

        public required string Descripcion {get; set;}
    }
}