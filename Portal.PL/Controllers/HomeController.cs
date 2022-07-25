using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortalPL.Controllers
{
    [Authorize(Roles = "Admin,Account")]


    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
