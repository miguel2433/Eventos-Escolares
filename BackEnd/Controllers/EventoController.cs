namespace BackEnd.Controllers
{
    public class EventoController : Controller
    {
        private readonly IRepoEvento _repoEvento;
        private readonly IRepoParticipacion _repoParticipacion;

        public EventoController(IRepoEvento repoEvento, IRepoParticipacion repoParticipacion)
        {
            _repoEvento = repoEvento;
            _repoParticipacion = repoParticipacion;
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
            var estudianteActualId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var evento = await _repoEvento.ObtenerPorId(idEvento);

            if (evento == null || evento.idEstudiante != estudianteActualId)
            {
                return Forbid();
            }

            await _repoParticipacion.EliminarParticipacionPorCondicion("idEvento = @idEvento", new { idEvento });
            
            await _repoEvento.Eliminar(idEvento);
            
            // Eliminar todas las participaciones asociadas al evento

            return RedirectToAction("Evento");
        }
    }
}
