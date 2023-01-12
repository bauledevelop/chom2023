using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
