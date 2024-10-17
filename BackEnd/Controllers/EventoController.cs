namespace BackEnd.Controllers
{
    public class EventoController : Controller
    {
        private readonly IRepoEvento _repoEvento;
        private readonly IRepoParticipacion _repoParticipacion;
        private readonly IRepoEstudiante _repoEstudiante;

        public EventoController(IRepoEvento repoEvento, IRepoParticipacion repoParticipacion, IRepoEstudiante repoEstudiante)
        {
            _repoEvento = repoEvento;
            _repoParticipacion = repoParticipacion;
            _repoEstudiante = repoEstudiante;
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

        [HttpPost]
        public async Task<IActionResult> EliminarEvento(int idEvento)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var estudiante = await _repoEstudiante.ObtenerPorId(int.Parse(userIdClaim));
            var evento = await _repoEvento.ObtenerPorId(idEvento);

            if (evento == null)
            {
                return NotFound();
            }

            if (estudiante.IsAdmin || evento.idEstudiante == estudiante.idEstudiante)
            {
                await _repoEvento.Eliminar(idEvento);
                return RedirectToAction("Evento");
            }

            return Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> BuscarEventos(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                TempData["MensajeBusqueda"] = "No se ha ingresado ningun titulo";
                return RedirectToAction("Evento");
            }
            var eventos = await _repoEvento.ObtenerEventosPorTitulo(titulo);
            if (eventos == null || !eventos.Any())
            {
                TempData["Mensaje"] = "No se ha encontrado ningún evento";
            }
            return View("Evento", eventos);
        }
    }
}
