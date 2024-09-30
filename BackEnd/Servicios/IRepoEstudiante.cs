namespace BackEnd.Servicios
{
    public interface IRepoEstudiante
    {
         Task<int> Crear(Estudiante estudiante);

         Task<Estudiante>? Obtener(int idEstudiante);

         Task<IEnumerable<Estudiante>> ObtenerPorCondicion(Func<Estudiante, bool> predicate);
    }
}