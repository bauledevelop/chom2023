using Microsoft.AspNetCore.Mvc;

namespace CHOM.Areas.Admin.Views.Shared.Components.SideBarViewComponent
{
    public class SideBarViewComponent : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
