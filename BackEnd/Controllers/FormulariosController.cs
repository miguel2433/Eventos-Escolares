using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Servicios; 


namespace BackEnd.Controllers
{
    public class FormulariosController : Controller
    {
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(contactoViewModel);
            }
            return RedirectToAction("Gracias");   
        }
    }
}