namespace BackEnd.Models
{
    public class Estudiante
    {
        public int idEstudiante { get; set; }

        public required string Nombre { get; set; }

        public required string Apellido { get; set; }

        public int? Anio { get; set; }

        public int? Division { get; set; }

        public required string Correo { get; set; }

        public required string Username { get; set; }

        public string? ImagenUrl { get; set; }

        public required string Contrasena { get; set; }

        public bool IsAdmin { get; set; }
    }
}
