namespace BackEnd.Servicios
{
    public interface IRepoEstudiante
    {
         Task Crear (Estudiante estudiante);

         Task<Estudiante> Obtener(int idEstudiante);
    }
}