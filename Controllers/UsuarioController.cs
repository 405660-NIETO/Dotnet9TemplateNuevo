using Microsoft.AspNetCore.Mvc;

namespace Programacion3Template.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
