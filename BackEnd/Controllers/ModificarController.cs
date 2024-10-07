namespace BackEnd.Controllers
{
    public class ModificarController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Campo de clase correcto
        private readonly IRepoEstudiante _repoEstudiante;

        public ModificarController(IRepoEstudiante repoEstudiante, IWebHostEnvironment environment) // Pasar el environment aquí
        {
            _environment = environment; // Asignar el environment inyectado
            _repoEstudiante = repoEstudiante;
        }

        public async Task<IActionResult> ModificarPerfil()
        {
            if (User.Identity.IsAuthenticated)
            {
                var estudiante = await _repoEstudiante.Obtener(Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
                return View(estudiante);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
          [HttpPost]
        public async Task<IActionResult> EditarFoto(IFormFile NuevaFotoPerfil)
        {
            if(ModelState.IsValid)
            {   
                
                string uniqueFileName = null;

                if(NuevaFotoPerfil != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Imagenes");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + NuevaFotoPerfil.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    NuevaFotoPerfil.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var estudiante = await _repoEstudiante.Obtener(Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
                estudiante.ImageUrl = uniqueFileName;

                _repoEstudiante.Update(estudiante);

            }
            return RedirectToAction("Perfil", "Perfil");
        }
    }
}
