using CHOM.Data;
using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class GalleryController : Controller
    {
        private readonly CHOMContext _db;
        public GalleryController(CHOMContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            try
            {
                var model = _db.BoSuuTams.ToList();
                return View(model);
            }
            catch(Exception ex)
            {
                return Redirect("/404");
            }
        }
    }
}
