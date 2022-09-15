using Microsoft.AspNetCore.Mvc;

namespace ProductMVC.Areas.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello World!");
        }
    }
}
