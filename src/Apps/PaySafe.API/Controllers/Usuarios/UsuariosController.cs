using Microsoft.AspNetCore.Mvc;

namespace PaySafe.API.Controllers.Usuarios
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
