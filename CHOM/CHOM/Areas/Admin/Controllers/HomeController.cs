using CHOM.Data;
using CHOM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        
        private readonly CHOMContext _context;
       
        public HomeController(CHOMContext context)
        {
         
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()

        {

            USER _user = new USER();

            return View(_user);

        }
        [HttpPost]

        public IActionResult Login(USER _user)

        {

           

            var status = _context.USER.Where(m => m.UserName == _user.UserName && m.UserPassword == _user.UserPassword).FirstOrDefault();

            if (status == null)

            {

                ViewBag.LoginStatus = 0;

            }

            else

            {

                return RedirectToAction("Index", "Home");

            }

            return View(_user);

        }
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
