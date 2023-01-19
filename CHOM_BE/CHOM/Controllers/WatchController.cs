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
            var listDuAn = _db.DuAns.SingleOrDefault(x => x.ID == int.Parse(id));
            ViewBag.Title = listDuAn.TuaDe;
            var checkPrev = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.ID < int.Parse(id) && x.IDMucLuc == 2);
            if (checkPrev == null)
            {
                ViewBag.Prev = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 2);
            }
            else
            {
                ViewBag.Prev = checkPrev;
            }
            var checkNext = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.ID > int.Parse(id) && x.IDMucLuc == 2);
            if (checkNext == null)
            {
                ViewBag.Next = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 2);
            }
            else
            {
                ViewBag.Next = checkNext;
            }
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
            var checkPrev = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.ID < int.Parse(id) && x.IDMucLuc == 3);
            if (checkPrev == null)
            {
                ViewBag.Prev = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 3);
            }
            else
            {
                ViewBag.Prev = checkPrev;
            }
            var checkNext = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.ID > int.Parse(id) && x.IDMucLuc == 3);
            if (checkNext == null)
            {
                ViewBag.Next = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 3);
            }
            else
            {
                ViewBag.Next = checkNext;
            }
            var model = _db.HinhAnhs.Where(x => x.IDDuAn == int.Parse(id));
            return View(model);
        }
    }
}
