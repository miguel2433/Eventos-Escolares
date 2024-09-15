using System.Diagnostics;

/*Reciben las peticiones http del usuario y dan una respuesta(Todos los controladores)*/
namespace BackEnd.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepoEstudiante repoEstudiante;

    public HomeController(ILogger<HomeController> logger
    ,IRepoEstudiante repoEstudiante)
    {
        _logger = logger;
        this.repoEstudiante = repoEstudiante;
    }
    
    public IActionResult Index()
    {
        return View();
    }
        
    [HttpPost]

    public async Task<IActionResult> Index(Estudiante estudiante)
    {
        if (!ModelState.IsValid)
        {
            return View(estudiante);
        }
        // Registra el modelo recibido para depuración
        estudiante.idEstudiante = 1;
        await repoEstudiante.Crear(estudiante);
        return RedirectToAction("Evento", "Evento");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
