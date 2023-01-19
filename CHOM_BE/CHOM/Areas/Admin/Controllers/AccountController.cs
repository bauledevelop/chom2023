using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly CHOMContext _db;
        public AccountController(CHOMContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.TaiKhoans.SingleOrDefault();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TaiKhoan taiKhoan)
        {
            if (!ModelState.IsValid) return View(taiKhoan);
            try
            {
                _db.Attach(taiKhoan);
                _db.Entry(taiKhoan).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Project");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Thay đổi thất bại";
                return View(taiKhoan);
            }
        }
    }
}
