namespace BackEnd.Servicios
{
    public class RepoEstudiante : IRepoEstudiante
    {
        private readonly string _connectionString;

        public RepoEstudiante(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        } 

        public async Task Crear(Estudiante estudiante)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Consulta para insertar un estudiante y obtener el ID recién insertado
                var query = @"
                    INSERT INTO Estudiante (Nombre, Apellido, Division, Año, Correo,ImageUrl) 
                    VALUES (@Nombre, @Apellido, @Division, @Año, @Correo,@ImageUrl);
                    SELECT LAST_INSERT_ID();";

                try
                {
                    // Ejecuta la consulta pasando el modelo de estudiante como parámetros
                    var id = await connection.QuerySingleAsync<int>(query, estudiante);
                    // Ahora puedes usar el ID si lo necesitas
                }
                catch (Exception ex)
                {
                    // Registra el error para depurar
                    Console.WriteLine("Error al insertar datos: " + ex.Message);
                }
            }
        }
    }
}
