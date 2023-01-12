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
            return View();
        }
        [HttpPost]
        [Area("Admin")]
        public IActionResult Login(TaiKhoan _user)
        {
           

            return View(_user);

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            
            return RedirectToAction("Login", "Home");
        }
    }
}
