namespace BackEnd.Servicios
{
    public interface IRepoEstudiante
    {
        public Task Crear (Estudiante estudiante);
    }
}