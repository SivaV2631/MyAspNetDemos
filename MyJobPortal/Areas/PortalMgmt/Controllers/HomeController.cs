using Microsoft.AspNetCore.Mvc;
using JobPortal.Models;

namespace JobPortal.Areas.PortalMgmt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new UserMV());
        }
    }
}
