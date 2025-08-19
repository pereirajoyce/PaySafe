using Microsoft.AspNetCore.Mvc;

namespace PaySafe.API.Controllers.Empresas
{
    public class EmpresasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
