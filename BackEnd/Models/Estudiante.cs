
namespace BackEnd.Models
{
    public class Estudiante
    {
        public int idEstudiante {get; set;}

        public required string Nombre {get; set;}
        
        public string Apellido {get;set;}

        public int Año {get; set;}

        public int Division {get;set;}

        public required string Correo {get; set;}

        public string ImageUrl {get;set;}
    }
}