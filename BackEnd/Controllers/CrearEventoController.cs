namespace BackEnd.Controllers
{
    public class CrearEventoController : Controller
    {
        private readonly IRepoEvento _repoEvento;
        private readonly IWebHostEnvironment _env;

        public CrearEventoController(IRepoEvento repoEvento, IWebHostEnvironment env)
        {
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
                var evento = model.evento;
                var imagen = model.Imagen;
                string uniqueFileName = null; // Declarar aquí

                if (imagen != null && imagen.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Imagenes");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + imagen.FileName; // Usar 'imagen'
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    try
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imagen.CopyToAsync(fileStream);
                        }

                        // Asignar la URL de la imagen al evento
                        model.evento.ImagenUrl = "/Imagenes/" + uniqueFileName; // Asegúrate de que la URL sea correcta
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Error al guardar la imagen: " + ex.Message);
                        return View(model); // Regresar a la vista con errores
                    }
                }

                var idAutoIncrementado = await _repoEvento.Crear(evento);
                evento.idEvento = idAutoIncrementado;

                return RedirectToAction("Evento", "Evento");
            }
            return View(model); // Regresar a la vista con errores de validación
        }
    }
}