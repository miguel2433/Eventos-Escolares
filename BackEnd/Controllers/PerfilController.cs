namespace BackEnd.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IRepoEstudiante repoEstudiante;

        public PerfilController(IRepoEstudiante repoEstudiante)
        {
            this.repoEstudiante = repoEstudiante;
        }
        

        public async Task<IActionResult> Perfil()
        {
            if (User.Identity.IsAuthenticated)
            {
                var estudiante = await repoEstudiante.Obtener(Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
                return View(estudiante);
            }
            // Devuelve una vista o redirección en caso de que el usuario no esté autenticado
            return RedirectToAction("Index", "Home"); // o cualquier otra acción que consideres apropiada
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
