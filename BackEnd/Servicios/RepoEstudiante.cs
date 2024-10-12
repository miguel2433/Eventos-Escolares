namespace BackEnd.Servicios
{
    public class RepoEstudiante : IRepoEstudiante
    {
        private readonly DbContext _dbContext;

        public RepoEstudiante(DbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public async Task<int> Crear(Estudiante estudiante)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = @"
                    INSERT INTO Estudiante (Nombre, Apellido, Division, Anio, Correo, ImagenUrl, Username, Contrasena) 
                    VALUES (@Nombre, @Apellido, @Division, @Anio, @Correo, @ImagenUrl, @Username, @Contrasena);
                    SELECT LAST_INSERT_ID();";
                var id = await connection.QuerySingleAsync<int>(query, estudiante);
                return id;
            }
        }

        public async Task<Estudiante>? Obtener(int idEstudiante)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Estudiante>(@"
                    SELECT *
                    FROM Estudiante
                    WHERE idEstudiante = @idEstudiante;", 
                    new { idEstudiante });
            }
        }

        public async Task<IEnumerable<Estudiante>> ObtenerPorCondicion(Func<Estudiante, bool> predicate)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var estudiantes = await connection.QueryAsync<Estudiante>(@"
                    SELECT * 
                    FROM Estudiante;");
                return estudiantes.Where(predicate).ToList();
            }
        }

        public async Task Update(Estudiante estudiante)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = @"
                    UPDATE Estudiante
                    SET Nombre = @Nombre,
                        Apellido = @Apellido,
                        Division = @Division,
                        Anio = @Anio,
                        Correo = @Correo,
                        ImageUrl = @ImageUrl,
                        Username = @Username,
                        Contrasena = @Contrasena
                    WHERE idEstudiante = @idEstudiante";
                var affectedRows = await connection.ExecuteAsync(query, estudiante);
            }
        }

        public async Task<IEnumerable<Estudiante>> ObtenerTodos()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Estudiante>("SELECT * FROM Estudiante");
            }
        }
    }
}
