namespace BackEnd.Servicios
{
    public interface IRepoEstudiante : IUpdate<Estudiante>
    {
         Task<int> Crear(Estudiante estudiante);

         Task<Estudiante>? ObtenerPorId(int idEstudiante);

         Task<IEnumerable<Estudiante>> ObtenerPorCondicion(Func<Estudiante, bool> predicate);

         Task<Estudiante>? ObtenerPorCorreo(string correo);

         
    }
}