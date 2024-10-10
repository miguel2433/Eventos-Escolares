namespace BackEnd.Controllers
{
    public class EventoController : Controller
    {
        private readonly IRepoEvento _repoEvento;

        public EventoController(IRepoEvento repoEvento)
        {
            _repoEvento = repoEvento;
        }
        public async Task<IActionResult> Evento()
        {
            var eventos = await _repoEvento.ObtenerTodos();
            return View(eventos);
        }
        [HttpGet]
        public async Task<IActionResult> Eventos()
        {
            var eventos = await _repoEvento.ObtenerTodos();
            
            // Verifica si la lista de eventos es nula o está vacía
            if (eventos == null || !eventos.Any())
            {
                // Puedes pasar un modelo vacío o un mensaje a la vista
                return View(new List<Evento>()); // O puedes redirigir a otra vista
            }
            
            return View(eventos);
        }
    }
}