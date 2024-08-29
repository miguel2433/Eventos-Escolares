using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Servicios;  // Asegúrate de que esta línea esté presente


namespace BackEnd.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        /*Instanciando un repoEstudiante*/
        var repoEstudiante = new RepoEstudiante();
        var estudiantes = repoEstudiante.ObtenerEstudiantes().Take(3).ToList();
        var modelo = new HomeIndexViewModel() {Estudiantes = estudiantes};
        return View(modelo);
    }

    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
