public class EventoCompletoController : Controller
{
    private readonly IRepoEvento _repoEvento;
    private readonly IRepoEstudiante _repoEstudiante;
    private readonly IRepoParticipacion _repoParticipacion;

    public EventoCompletoController(IRepoEstudiante repoEstudiante, IRepoEvento repoEvento, IRepoParticipacion repoParticipacion)
    {
        _repoEstudiante = repoEstudiante;
        _repoEvento = repoEvento;
        _repoParticipacion = repoParticipacion;
    }
    public async Task<IActionResult> EventoCompleto(int id)
    {
        var evento = await _repoEvento.ObtenerPorId(id);
        var EstudianteCreador = await _repoEstudiante.ObtenerPorId(evento.idEstudiante);
        var participaciones = await _repoParticipacion.ObtenerPorCondicion("idEvento = @idEvento", new { idEvento = id });

        // Convertir las participaciones en estudiantes
        var estudiantes = new List<Estudiante>();
        foreach (var participacion in participaciones)
        {
            var estudiante = await _repoEstudiante.ObtenerPorId(participacion.idEstudiante);
            if (estudiante != null)
            {
                estudiantes.Add(estudiante);
            }
        }

        var EventoCompletoModel = new EventoCompletoViewModel
        {
            Estudiante = EstudianteCreador,
            Evento = evento,
            Estudiantes = estudiantes
        };

        if (EventoCompletoModel == null || EventoCompletoModel.Evento == null || EventoCompletoModel.Estudiante == null)
        {
            // Manejar el caso de modelo nulo, por ejemplo, redirigir a una página de error
            return RedirectToAction("Index", "Home");
        }

        return View(EventoCompletoModel);
    }

    [HttpPost]
    public async Task<IActionResult> Inscribirse(int idEvento)
    {
        var EstudianteActual = await _repoEstudiante.ObtenerPorId(Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value));

        // Verificar si la participación ya existe
        var existingParticipation = await _repoParticipacion.ObtenerPorCondicion("idEvento = @idEvento AND idEstudiante = @idEstudiante", new { idEvento, idEstudiante = EstudianteActual.idEstudiante });

        if (existingParticipation.Any())
        {
            TempData["ErrorMessage"] = "Ya estás inscrito en este evento";
            return RedirectToAction("EventoCompleto", new { id = idEvento });
        }

        var participacion = new Participacion
        {
            idEvento = idEvento,
            idEstudiante = EstudianteActual.idEstudiante
        };
        var idAutoIncremental = await _repoParticipacion.Crear(participacion);
        participacion.idParticipacion = idAutoIncremental;

        // Recuperar al estudiante con el mismo idEstudiante de la participación
        var estudiante = await _repoEstudiante.ObtenerPorId(participacion.idEstudiante);
        
        // Obtener el evento y las participaciones actuales
        var evento = await _repoEvento.ObtenerPorId(idEvento);
        var participaciones = await _repoParticipacion.ObtenerPorCondicion("idEvento = @idEvento", new { idEvento = idEvento });

        // Convertir las participaciones en estudiantes
        var estudiantes = new List<Estudiante>();
        foreach (var p in participaciones)
        {
            var e = await _repoEstudiante.ObtenerPorId(p.idEstudiante);
            if (e != null)
            {
                estudiantes.Add(e);
            }
        }

        // Agregar el estudiante actual a la lista
        if (estudiante != null && !estudiantes.Any(e => e.idEstudiante == estudiante.idEstudiante))
        {
            estudiantes.Add(estudiante);
        }

        var EventoCompletoModel = new EventoCompletoViewModel
        {
            Estudiante = EstudianteActual,
            Evento = evento,
            Estudiantes = estudiantes
        };

        return View("EventoCompleto", EventoCompletoModel);
    }



}



