using CHOM.Data;
using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class WatchController : Controller
    {
        private readonly CHOMContext _db;
        public WatchController(CHOMContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Landscape(string id)
        {
            ViewBag.ID = id;
            ViewBag.Title = _db.DuAns.SingleOrDefault(x => x.ID == int.Parse(id)).TuaDe;
            var model = _db.HinhAnhs.Where(x => x.IDDuAn == int.Parse(id));
            return View(model);
        }
        [HttpGet]
        public IActionResult Interior(string id)
        {
            ViewBag.ID = id;
            var project = _db.DuAns.SingleOrDefault(x => x.ID == int.Parse(id));
            ViewBag.Title = project.TuaDe;
            ViewBag.Image = project.HinhGT;
            var model = _db.HinhAnhs.Where(x => x.IDDuAn == int.Parse(id));
            return View(model);
        }
    }
}
