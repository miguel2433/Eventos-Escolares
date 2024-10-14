namespace BackEnd.Controllers
{
    public class CrearEventoController : Controller
    {
        private readonly IRepoEvento _repoEvento;
        private readonly IRepoEstudiante _repoEstudiante;
        private readonly IWebHostEnvironment _env;

        public CrearEventoController(IRepoEstudiante repoEstudiante, IRepoEvento repoEvento, IWebHostEnvironment env)
        {
            _repoEstudiante = repoEstudiante ?? throw new ArgumentNullException(nameof(repoEstudiante));
            _repoEvento = repoEvento ?? throw new ArgumentNullException(nameof(repoEvento));
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public IActionResult CrearEvento()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearEvento(CrearEventoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    ModelState.AddModelError("", "El usuario no está autenticado.");
                    return View(model);
                }

                var EstudianteActual = await _repoEstudiante.ObtenerPorId(Convert.ToInt32(userIdClaim));
                if (EstudianteActual == null)
                {
                    ModelState.AddModelError("", "Estudiante no encontrado.");
                    return View(model);
                }

                var evento = model.evento;
                evento.idEstudiante = EstudianteActual.idEstudiante;

                var imagen = model.Imagen;
                string uniqueFileName = null;

                if (imagen != null && imagen.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Imagenes");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imagen.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    try
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imagen.CopyToAsync(fileStream);
                        }

                        evento.ImagenUrl = uniqueFileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Error al guardar la imagen: " + ex.Message);
                        return View(model);
                    }
                }

                try
                {
                    var idAutoIncrementado = await _repoEvento.Crear(evento);
                    evento.idEvento = idAutoIncrementado;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el evento: " + ex.Message);
                    return View(model);
                }

                return RedirectToAction("Evento", "Evento");
            }
            return View(model); // Regresar a la vista con errores de validación
        }
    }
}
