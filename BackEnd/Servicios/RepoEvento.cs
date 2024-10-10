namespace BackEnd.Servicios
{
    public class RepoEvento : IRepoEvento
    {
        private readonly string _connectionString;

        public RepoEvento(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        } 

        public async Task<int> Crear(Evento evento)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Consulta para insertar un evento y obtener el ID recién insertado
                var query = @"
                    INSERT INTO Evento (Nombre, Fecha, Ubicacion, Descripcion,ImagenUrl) 
                    VALUES (@Nombre, @Fecha, @Ubicacion, @Descripcion, @ImagenUrl);
                    SELECT LAST_INSERT_ID();";
                    // Ejecuta la consulta pasando el modelo de estudiante como parámetros
                var id = await connection.QuerySingleAsync<int>(query, evento);
                // Ahora puedes usar el ID si lo necesitas
                return id;
                
            }
        }
        public async Task<Evento>? Obtener(int idEvento)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Este método devolverá solo un evento con el id proporcionado
                return await connection.QuerySingleOrDefaultAsync<Evento>(@"
                    SELECT *
                    FROM Evento
                    WHERE idEvento = @idEvento;", 
                    new { idEvento });
            }
        }

        public async Task<IEnumerable<Evento>> ObtenerPorCondicion(Func<Evento, bool> predicate)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Primero traemos todos los eventos
                var eventos = await connection.QueryAsync<Evento>(@"
                    SELECT * 
                    FROM Evento;");
    
                // Luego aplicamos el predicado en memoria
                return eventos.Where(predicate).ToList();
            }
        }

        public async Task Update(Evento evento)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Consulta para actualizar el estudiante
                var query = @"
                    UPDATE Evento
                    SET Nombre = @Nombre,
                        Fecha = @Fecha,
                        Ubicacion = @Ubicacion,
                        Descripcion = @Descripcion,
                        ImagenUrl = @ImagenUrl,
                    WHERE idEvento = @idEvento";

                // Ejecuta la consulta de actualización
                var affectedRows = await connection.ExecuteAsync(query, evento);
            }
            }
    
            public async Task<IEnumerable<Evento>> ObtenerTodos()
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    return await connection.QueryAsync<Evento>("SELECT * FROM Evento");
                }
            }

    }
}

