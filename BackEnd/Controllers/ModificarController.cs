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

        public async Task<IActionResult> ModificarPerfil(ModificarViewModel modificarViewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                var estudiante = await _repoEstudiante.ObtenerPorId(Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
                modificarViewModel.estudiante = estudiante;
                return View(modificarViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditarFoto(IFormFile NuevaFotoPerfil)
        {
            if (ModelState.IsValid)
            {   
                string uniqueFileName = null;
        
                // Obtener al estudiante actual
                var estudiante = await _repoEstudiante.ObtenerPorId(Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
        
                // Si el estudiante ya tiene una foto guardada, eliminarla
                if (!string.IsNullOrEmpty(estudiante.ImagenUrl))
                {
                    string existingFilePath = Path.Combine(_environment.WebRootPath, "Imagenes", estudiante.ImagenUrl);
        
                    if (System.IO.File.Exists(existingFilePath))
                    {
                        System.IO.File.Delete(existingFilePath); // Eliminar la imagen anterior
                    }
                }
        
                // Guardar la nueva foto de perfil
                if (NuevaFotoPerfil != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Imagenes");
        
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + NuevaFotoPerfil.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        
                    // Guardar la nueva imagen en el servidor
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await NuevaFotoPerfil.CopyToAsync(fileStream);
                    }
        
                    // Actualizar la URL de la imagen del estudiante
                    estudiante.ImagenUrl = uniqueFileName;
                    await _repoEstudiante.Update(estudiante);
                }
        
                return RedirectToAction("Perfil", "Perfil");
            }
        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GuardarCambios(ModificarViewModel modificarViewModel)
        {   
            var estudiante = await _repoEstudiante.ObtenerPorId(Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // Ver el contenido de los errores para encontrar el problema
            }
            // Asignar los nuevos valores
            estudiante.Nombre = modificarViewModel.estudiante.Nombre;
            estudiante.Apellido = modificarViewModel.estudiante.Apellido;
            estudiante.Username = modificarViewModel.estudiante.Username;
            // Actualizar los cambios en la base de datos
            await _repoEstudiante.Update(estudiante);
            // Redirigir a la vista del perfil
            return RedirectToAction("Perfil", "Perfil");
        }
    }
}
