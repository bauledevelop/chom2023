using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
