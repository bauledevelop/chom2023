using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LienHe lienHe)
        {
            if (!ModelState.IsValid) return View(lienHe);
            try
            {
                await _db.AddAsync(lienHe);
                await _db.SaveChangesAsync();
                return Redirect("/Admin/SocialMedia");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Tạo liên hệ thất bại";
                return View();
            }
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
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var check = await _db.LienHes.SingleOrDefaultAsync(x => x.ID == int.Parse(id));
                if (check != null)
                {
                    _db.LienHes.Remove(check);
                    await _db.SaveChangesAsync();
                    return Json(new
                    {
                        status = true
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }
            return Json(new
            {
                status = false
            });
        }
    }
}
