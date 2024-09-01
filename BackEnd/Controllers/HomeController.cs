using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Servicios;  // Asegúrate de que esta línea esté presente

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
        /*Instanciando un repoEstudiante*/
        var estudiantes = repoEstudiante.ObtenerEstudiantes().Take(3).ToList();
        var modelo = new HomeIndexViewModel() {Estudiantes = estudiantes};
        return View(modelo);
    }

    
    public IActionResult Estudiantes()
    {
        var estudiantes = repoEstudiante.ObtenerEstudiantes();
        return View(estudiantes);
    }


    public IActionResult Gracias()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
