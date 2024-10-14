namespace BackEnd.Servicios
{
    public class RepoEvento : IRepoEvento
    {
        private readonly DbContext _dbContext;

        public RepoEvento(DbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public async Task<int> Crear(Evento evento)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = @"
                    INSERT INTO Evento (Nombre, Fecha, Ubicacion, Descripcion, ImagenUrl, idEstudiante) 
                    VALUES (@Nombre, @Fecha, @Ubicacion, @Descripcion, @ImagenUrl, @idEstudiante);
                    SELECT LAST_INSERT_ID();";
                var id = await connection.QuerySingleAsync<int>(query, evento);
                return id;
            }
        }

        public async Task<Evento>? ObtenerPorId(int idEvento)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Evento>(@"
                    SELECT *
                    FROM Evento
                    WHERE idEvento = @idEvento;", 
                    new { idEvento });
            }
        }

        public async Task<IEnumerable<Evento>> ObtenerPorCondicion(Func<Evento, bool> predicate)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var eventos = await connection.QueryAsync<Evento>(@"
                    SELECT * 
                    FROM Evento;");
                return eventos.Where(predicate).ToList();
            }
        }

        public async Task Update(Evento evento)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = @"
                    UPDATE Evento
                    SET Nombre = @Nombre,
                        Fecha = @Fecha,
                        Ubicacion = @Ubicacion,
                        Descripcion = @Descripcion,
                        ImagenUrl = @ImagenUrl,
                        idEstudiante = @idEstudiante
                    WHERE idEvento = @idEvento";
                var affectedRows = await connection.ExecuteAsync(query, evento);
            }
        }

        public async Task<IEnumerable<Evento>> ObtenerTodos()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Evento>("SELECT * FROM Evento");
            }
        }
    }
}
