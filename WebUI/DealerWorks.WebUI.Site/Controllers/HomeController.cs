using Microsoft.AspNetCore.Mvc;

namespace DealerWorks.WebUI.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
