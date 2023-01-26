using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Mvc.Entensions;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly CHOMContext _db;
        public FeedbackController(CHOMContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            var model = _db.PhanHois.OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var check = await _db.PhanHois.SingleOrDefaultAsync(x => x.ID == int.Parse(id));
                if (check != null)
                {
                    _db.PhanHois.Remove(check);
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
