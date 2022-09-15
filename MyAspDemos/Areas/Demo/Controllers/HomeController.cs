using Microsoft.AspNetCore.Mvc;
using MyAspDemos.Areas.Demo.ViewModels;

namespace MyAspDemos.Areas.Demo.Controllers
{
    [Area("Demo")]          // Register the Route for the Controller to the Area
    public class HomeController : Controller
    {
       
        // HTTP GET https://localhost:xxxx/Demo
        // HTTP GET https://localhost:xxxx/Demo/Home
        // HTTP GET https://localhost:xxxx/Demo/Home/Index
        // ROUTE: url / {area} / {controller} / {action}
        public IActionResult Index()
        {
            return Ok("Hello World!This is Siva!");          // HTTP Response 200 "Ok"
        }


        // HTTP GET https://localhost:xxxx/Demo/Home/Index2
        public IActionResult Index2()
        {
            return View();
        }

        // HTTP GET
        public IActionResult DisplayCustomer()
        {
            CustomerViewModel viewModel = new CustomerViewModel()
            {
                CustomerId = 1,
                CreatedOn = System.DateTime.Now
            };
            return View(viewModel);
        }

        // HTTP GET
        public IActionResult DisplayEmployee()
        {
            EmployeeFormViewModel viewModel = new EmployeeFormViewModel()
            {
                EmployeeId = 1,
                LoggedOn = System.DateTime.Now

            };
            return View(viewModel);
        }


        // To address over-posting ensure that the [Bind] attribute lists all the needed properties.
        // NOTE: the names of the properties is CASE-SENSITIVE.
        // HTTP POST
        [HttpPost]
        [ValidateAntiForgeryToken]                      // to address JavaScript Injection Attacks
        public IActionResult DisplayCustomer(
            [Bind("CustomerId,CustomerName,Email,Balance")] CustomerViewModel viewModel)
        {
            return View(viewModel);
        }

        // To address over-posting ensure that the [Bind] attribute lists all the needed properties.
        // NOTE: the names of the properties is CASE-SENSITIVE.
        // HTTP POST
        [HttpPost]
        [ValidateAntiForgeryToken]                      // to address JavaScript Injection Attacks
        public IActionResult DisplayEmployee(
             CustomerViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
