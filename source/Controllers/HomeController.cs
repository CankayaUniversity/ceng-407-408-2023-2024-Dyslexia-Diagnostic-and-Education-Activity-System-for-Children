using Microsoft.AspNetCore.Mvc;

namespace DyslexiaEduGameApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
