namespace BackEnd.Servicios
{
    public interface IRepoParticipacion 
    {
         Task<int> Crear(Participacion participacion);

         Task<Participacion>? ObtenerPorId(int idParticipacion);

         Task<IEnumerable<Participacion>> ObtenerPorCondicion(string condicionSql, object parametros);

         Task<Participacion>? ObtenerPorEventoYEstudiante(int idEvento, int idEstudiante);
    }
}