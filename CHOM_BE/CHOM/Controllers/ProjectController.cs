using CHOM.Data;
using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class ProjectController : Controller
    {
        private readonly CHOMContext _db;
        public ProjectController(CHOMContext db)
        {
            _db = db;
        }

        [HttpGet("/Project/{id?}")]
        public IActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id)) return Redirect("/404");
            try
            {
                var model = _db.DuAns.Where(x => x.IDMucLuc == int.Parse(id)).OrderByDescending(x => x.ID).ToList();
                ViewBag.Menu = _db.MucLucs.SingleOrDefault(x => x.ID == int.Parse(id)).ID;
                return View(model);
            }
            catch(Exception ex)
            {
                return Redirect("/404");
            }
        }
    }
}
