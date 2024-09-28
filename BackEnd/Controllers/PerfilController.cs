namespace BackEnd.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IRepoEstudiante repoEstudiante;

        public PerfilController(IRepoEstudiante repoEstudiante)
        {
            this.repoEstudiante = repoEstudiante;
        }
        
        public async Task<IActionResult> Perfil()
        {
            var idEstudiante = 1;
            var estudiante = await repoEstudiante.Obtener(idEstudiante);
            return View(estudiante);
        }
    }
}