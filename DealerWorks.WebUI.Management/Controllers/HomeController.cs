using Microsoft.AspNetCore.Mvc;

namespace DealerWorks.WebUI.Management.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
