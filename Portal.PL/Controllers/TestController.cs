using Microsoft.AspNetCore.Mvc;

namespace PortalPL.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
