namespace BackEnd.Controllers
{
    public class FormulariosController : Controller
    {
        private readonly IRepoEstudiante repoEstudiante;

        public FormulariosController(IRepoEstudiante repoEstudiante)
        {
            this.repoEstudiante = repoEstudiante;
        }

        public IActionResult Contacto()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Contacto(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return View(estudiante);
            }

            // Registra el modelo recibido para depuración
            estudiante.idEstudiante = 1;

            await repoEstudiante.Crear(estudiante);

            return View();
        }
    }
}
