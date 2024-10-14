namespace BackEnd.Servicios
{
    public class RepoParticipacion : IRepoParticipacion
    {
        private readonly DbContext _contexto;

        public RepoParticipacion(DbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Crear(Participacion participacion)
        {
            using (var connection = _contexto.CreateConnection())
            {
                try
                {
                    var query = @"
                    INSERT INTO Participaciones (idEvento, idEstudiante) 
                    VALUES (@idEvento, @idEstudiante);
                    SELECT LAST_INSERT_ID();";
                    var id = await connection.QuerySingleAsync<int>(query, participacion);
                    return id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
        
        public async Task<Participacion>? ObtenerPorId(int idParticipacion)
        {
            using (var connection = _contexto.CreateConnection())
            {
                var query = "SELECT * FROM Participaciones WHERE idParticipacion = @idParticipacion";
                return await connection.QuerySingleOrDefaultAsync<Participacion>(query, new { idParticipacion });
            }
        }

        public async Task<IEnumerable<Participacion>> ObtenerPorCondicion(string condicionSql, object parametros)
        {
            using (var connection = _contexto.CreateConnection())
            {
                var query = $"SELECT * FROM Participaciones WHERE {condicionSql}";
                return await connection.QueryAsync<Participacion>(query, parametros);
            }
        
        }

        public async Task<Participacion>? ObtenerPorEventoYEstudiante(int idEvento, int idEstudiante)
        {
            using (var connection = _contexto.CreateConnection())
            {
                var query = "SELECT * FROM Participaciones WHERE idEvento = @idEvento AND idEstudiante = @idEstudiante";
                return await connection.QuerySingleOrDefaultAsync<Participacion>(query, new { idEvento, idEstudiante });
            }
        }
    }
}
