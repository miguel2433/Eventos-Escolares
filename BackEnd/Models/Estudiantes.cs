
namespace BackEnd.Models
{
    public class Estudiantes
    {
        public int idEstudiante {get; set;}

        public required string Nombre {get; set;}

        public required string Grado {get; set;}

        public required string Correo {get; set;}
    }
}