using BCrypt.Net;


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
    public async Task<IActionResult> Login(IndexViewModel index)
    {
        if (ModelState.IsValid)
        {
            // Buscar el usuario existente por correo
            var usuarioExistente = (await repoEstudiante.ObtenerPorCondicion(estudiante => estudiante.Correo == index.Login.CorreoLogin)).FirstOrDefault();

            Console.WriteLine($"Intento de login para correo: {index.Login.CorreoLogin}");
            Console.WriteLine($"Usuario encontrado: {usuarioExistente != null}");

            // Verificar si el usuario existe
            if (usuarioExistente != null)
            {
                Console.WriteLine($"Username coincide: {usuarioExistente.Username == index.Login.UsernameLogin}");
                if(usuarioExistente.Username == index.Login.UsernameLogin)
                {
                    // Verificar la contraseña
                    bool passwordVerified = BCrypt.Net.BCrypt.Verify(index.Login.ContrasenaLogin, usuarioExistente.Contrasena);
                    Console.WriteLine($"Contraseña verificada: {passwordVerified}");

                    if (passwordVerified)
                    {
                        // Crear las reclamaciones del usuario
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, usuarioExistente.idEstudiante.ToString()),
                            new Claim(ClaimTypes.Name, usuarioExistente.Username),
                            new Claim(ClaimTypes.Email, usuarioExistente.Correo)
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        // Iniciar sesión
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("Evento", "Evento");
                    }
                    else
                    {
                        // Contraseña incorrecta
                        ModelState.AddModelError("Login.ContrasenaLogin", "Contraseña incorrecta.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Login.UsernameLogin", "Nombre de usuario Incorrecto");
                }
            }
            else
            {
                // Correo no registrado
                ModelState.AddModelError("Login.CorreoLogin", "Correo Electrónico no registrado.");
            }
        }

        // Redirigir a Home/Index si el ModelState no es válido o si hay errores
        return View("index", index);
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
            Nombre = index.Register.Nombre,
            Apellido = index.Register.Apellido,
            Anio = index.Register.Anio,
            Division = index.Register.Division,
            Correo = index.Register.Correo,
            Username = index.Register.Username,
            ImagenUrl = "",
            Contrasena = BCrypt.Net.BCrypt.HashPassword(index.Register.Contrasena)
        };
        
        var idAutoIncrementado = await repoEstudiante.Crear(estudiante);
        estudiante.idEstudiante = idAutoIncrementado;

        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, estudiante.idEstudiante.ToString()),
                new Claim(ClaimTypes.Name, estudiante.Nombre),
                new Claim(ClaimTypes.Email, estudiante.Correo)
            };

        if (estudiante.IsAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }

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



