using Microsoft.AspNetCore.Mvc;
using BackEnd.Servicios;

namespace BackEnd.Controllers
{
    public class LoginController : Controller
    {
    public IActionResult Login()
    {
        /*Instanciando un repoEstudiante*/
        return View();
    }
    
    }
}