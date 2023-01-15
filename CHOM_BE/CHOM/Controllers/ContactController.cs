using CHOM.Data;
using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class ContactController : Controller
    {
        private readonly CHOMContext _db;
        public ContactController(CHOMContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.About = _db.Abouts.SingleOrDefault(x => x.ID != 0);
            var model = _db.DoiNgus.ToList();
            ViewBag.LienHe = _db.LienHes.ToList();
            return View(model);
        }
    }
}
