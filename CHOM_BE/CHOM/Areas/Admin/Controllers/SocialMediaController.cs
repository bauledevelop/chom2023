using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Mvc.Entensions;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SocialMediaController : Controller
    {
        private readonly CHOMContext _db;
        public SocialMediaController(CHOMContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            var model = _db.LienHes.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _db.LienHes.Find(int.Parse(id));
                return View(model);
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LienHe lienHe)
        {
            if (!ModelState.IsValid) return View(lienHe);
            try
            {
                if (lienHe.PhuongThuc == "Phone")
                {
                    if (lienHe.Ten.Length > 12)
                    {
                        ViewBag.Message = "Vui lòng chỉ nhập 12 kí tự";
                        return View(lienHe);
                    }
                    for(var i=0;i<lienHe.Ten.Length;i++)
                    {
                        if (lienHe.Ten[i] < '0' || lienHe.Ten[i] >'9')
                        {
                            ViewBag.Message = "Vui lòng chỉ nhập số";
                            return View(lienHe);
                        }
                    }
                }
                _db.Attach(lienHe);
                _db.Entry(lienHe).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Redirect("/Admin/SocialMedia");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Tạo liên hệ thất bại";
            }
            return View(lienHe);
        }
    }
}
