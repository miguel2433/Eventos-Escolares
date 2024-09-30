namespace BackEnd.Servicios
{
    public class RepoEstudiante : IRepoEstudiante
    {
        private readonly string _connectionString;

        public RepoEstudiante(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        } 

        public async Task<int> Crear(Estudiante estudiante)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Consulta para insertar un estudiante y obtener el ID recién insertado
                var query = @"
                    INSERT INTO Estudiante (Nombre, Apellido, Division, Año, Correo,ImageUrl,Username,Contraseña) 
                    VALUES (@Nombre, @Apellido, @Division, @Año, @Correo,@ImageUrl,@Username,@Contraseña);
                    SELECT LAST_INSERT_ID();";
                    // Ejecuta la consulta pasando el modelo de estudiante como parámetros
                var id = await connection.QuerySingleAsync<int>(query, estudiante);
                // Ahora puedes usar el ID si lo necesitas
                return id;
                
            }
        }
        public async Task<Estudiante>? Obtener(int idEstudiante)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Este método devolverá solo un estudiante con el id proporcionado
                return await connection.QuerySingleOrDefaultAsync<Estudiante>(@"
                    SELECT *
                    FROM Estudiante
                    WHERE idEstudiante = @idEstudiante;", 
                    new { idEstudiante });
            }
        }

        public async Task<IEnumerable<Estudiante>> ObtenerPorCondicion(Func<Estudiante, bool> predicate)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Primero traemos todos los estudiantes
                var estudiantes = await connection.QueryAsync<Estudiante>(@"
                    SELECT * 
                    FROM Estudiante;");
    
                // Luego aplicamos el predicado en memoria
                return estudiantes.Where(predicate).ToList();
            }
        }

    }
}
