using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySql.Data.MySqlClient; // Asegúrate de tener este espacio de nombres si usas MySQL.
using BackEnd.Models;
using Microsoft.Extensions.Configuration;
using BackEnd.Servicios;

namespace BackEnd.Controllers
{
    public class FormulariosController : Controller
    {
        private readonly IRepoEstudiante repoEstudiante;

        public FormulariosController(IRepoEstudiante repoEstudiante)
        {
            this.repoEstudiante = repoEstudiante;
        }

        public IActionResult Contacto()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Contacto(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return View(estudiante);
            }

            // Registra el modelo recibido para depuración
            estudiante.idEstudiante = 1;

            repoEstudiante.Crear(estudiante);

            return View();
        }
    }
}
