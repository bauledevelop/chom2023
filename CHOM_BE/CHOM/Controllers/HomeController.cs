using CHOM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CHOM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      
/*
        public IActionResult Index(EmpoyeeModel _empoyeeModel)

        {

            EmployeeContext _employeeContext = new EmployeeContext();

            var status = _employeeContext.EmployeeLogin.Where(m => m.LoginId == _empoyeeModel.LoginId && m.Password == _empoyeeModel.Pasword).FirstOrDefault();

            if (status == null)

            {

                ViewBag.LoginStatus = 0;

            }

            else

            {

                return RedirectToAction("SuccessPage", "Home");

            }

            return View(_empoyeeModel);

        }
*/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}