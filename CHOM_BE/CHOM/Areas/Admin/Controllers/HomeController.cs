using CHOM.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        
        private readonly CHOMContext _db;
       
        public HomeController(CHOMContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        [Route("/admin/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Area("Admin")]
        public async Task<IActionResult> Login(TaiKhoan _user)
        {
            if (!ModelState.IsValid) return View(_user);
            try
            {
                var account = _db.TaiKhoans.SingleOrDefault(x => x.UserName == _user.UserName);
                if (account != null)
                {
                    if (account.Password == _user.Password)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,account.UserName)
                        };
                        var identity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme
                            );
                        var princial = new ClaimsPrincipal(identity);
                        var props = new AuthenticationProperties();
                        HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme, princial, props).Wait();
                        return Redirect("/Admin/Project");
                    }
                    ViewBag.Message = "Mật khẩu không chính xác";
                }
                else
                {
                    ViewBag.Message = "Tài khoản không tồn tại";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Tài khoản không tồn tại";
            }
            return View(_user);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("/Admin/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
    }
}
