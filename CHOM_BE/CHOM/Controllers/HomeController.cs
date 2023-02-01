using CHOM.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CHOM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CHOMContext _db;
        public HomeController(ILogger<HomeController> logger,CHOMContext db)
        {
            _logger = logger;
            _db = db;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Video = _db.Videos.SingleOrDefault();
            ViewBag.TitleIndex = "Checked";
             
            return View();
        }
        [Route("/Home")]
        public IActionResult Home()
        {
            try
            {
                ViewBag.LoaiPage = 0;
                ViewBag.Interior = _db.MucLucs.SingleOrDefault(x => x.ID == 3);
                ViewBag.Landscape = _db.MucLucs.SingleOrDefault(x => x.ID == 2);
                return View();
            }
            catch(Exception ex)
            {
                return Redirect("/404");
            }
        }
        [Route("/404")]
        public IActionResult Error()
        {
            ViewBag.Error = "true";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}