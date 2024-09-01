
namespace BackEnd.Models
{
    public class Estudiante
    {
        public int idEstudiante {get; set;}

        public required string Nombre {get; set;}

        public string Apellido {get;set;}

        public byte Año {get; set;}

        public byte Division {get;set;}

        public required string Correo {get; set;}

        public string ImageUrl {get;set;}
    }
}