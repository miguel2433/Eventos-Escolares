namespace BackEnd.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IRepoEstudiante _repoEstudiante;
        private readonly IRepoParticipacion _repoParticipacion;
        private readonly IRepoEvento _repoEvento;

        public PerfilController(IRepoEstudiante repoEstudiante, IRepoParticipacion repoParticipacion, IRepoEvento repoEvento)
        {
            _repoEstudiante = repoEstudiante;
            _repoParticipacion = repoParticipacion;
            _repoEvento = repoEvento;
        }

        public async Task<IActionResult> Perfil()
        {
            var idEstudiante = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var estudiante = await _repoEstudiante.ObtenerPorId(idEstudiante);
            
            var participaciones = await _repoParticipacion.ObtenerPorCondicion("idEstudiante = @idEstudiante", new { idEstudiante });
            var eventosInscritos = new List<Evento>();
            
            foreach (var participacion in participaciones)
            {
                var evento = await _repoEvento.ObtenerPorId(participacion.idEvento);
                if (evento != null)
                {
                    eventosInscritos.Add(evento);
                }
            }

            var viewModel = new PerfilViewModel
            {
                Estudiante = estudiante,
                EventosInscritos = eventosInscritos
            };

            return View(viewModel);
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
