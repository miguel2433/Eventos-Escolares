namespace BackEnd.Servicios
{
    public interface IRepoEvento : IUpdate<Evento>
    {
        Task<int> Crear(Evento evento);

        Task<Evento>? Obtener(int idEvento);

        Task<IEnumerable<Evento>> ObtenerPorCondicion(Func<Evento, bool> predicate);
    
        Task<IEnumerable<Evento>> ObtenerTodos();
    }
}