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
            ViewBag.Interior = _db.MucLucs.SingleOrDefault(x => x.Ten == "Interior");
            ViewBag.Landscape = _db.MucLucs.SingleOrDefault(x => x.Ten == "Landscape");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}