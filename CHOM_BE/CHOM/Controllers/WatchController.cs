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
            ViewBag.TuaDe = listDuAn.TuaDe;
            var listCount = _db.DuAns.Where(x => x.IDMucLuc == listDuAn.IDMucLuc).OrderByDescending(x => x.ID).ToList();
            ViewBag.MAX = listCount.Count();
            var count = 0;
            ViewBag.BackList = listDuAn.IDMucLuc;
            foreach(var item in listCount)
            {
                count++;
                if (item.ID == int.Parse(id))
                {
                    break;
                }
            }
            ViewBag.MIN = count;
            var checkPrev = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.ID > int.Parse(id) && x.IDMucLuc == 2);
            if (checkPrev == null)
            {
                ViewBag.Prev = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 2);
            }
            else
            {
                ViewBag.Prev = checkPrev;
            }
            var checkNext = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.ID < int.Parse(id) && x.IDMucLuc == 2);
            if (checkNext == null)
            {
                ViewBag.Next = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 2);
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
            ViewBag.Image = project.HinhGT;
            var listCount = _db.DuAns.Where(x => x.IDMucLuc == project.IDMucLuc).OrderByDescending(x => x.ID).ToList();
            ViewBag.MAX = listCount.Count();
            ViewBag.BackList = project.IDMucLuc;
            var count = 0;
            foreach (var item in listCount)
            {
                count++;
                if (item.ID == int.Parse(id))
                {
                    break;
                }
            }
            ViewBag.Min = count;
            var checkPrev = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.ID > int.Parse(id) && x.IDMucLuc == 2);
            if (checkPrev == null)
            {
                ViewBag.Prev = _db.DuAns.OrderBy(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 2);
            }
            else
            {
                ViewBag.Prev = checkPrev;
            }
            var checkNext = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.ID < int.Parse(id) && x.IDMucLuc == 2);
            if (checkNext == null)
            {
                ViewBag.Next = _db.DuAns.OrderByDescending(x => x.ID).FirstOrDefault(x => x.IDMucLuc == 2);
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
