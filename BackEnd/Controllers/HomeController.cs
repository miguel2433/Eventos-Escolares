

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

    public async Task<IActionResult> Index(IndexViewModel index)
    {
        if (!ModelState.IsValid)
        {
            return View(index);
        }
        // Registra el modelo recibido para depuración


        var estudiante = new Estudiante()
        {
            Nombre = index.Nombre,
            Apellido = index.Apellido,
            Año = index.Año,
            Division = index.Division,
            Correo = index.Correo,
            Username = index.Username,
            ImageUrl = "",
            Contraseña = index.Contraseña
        };
        
        var idAutoIncrementado = await repoEstudiante.Crear(estudiante);
        estudiante.idEstudiante = idAutoIncrementado;

        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, estudiante.idEstudiante.ToString()),
                new Claim(ClaimTypes.Name, estudiante.Nombre),
                new Claim(ClaimTypes.Email, estudiante.Correo)
            };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);  
        return RedirectToAction("Evento", "Evento");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
