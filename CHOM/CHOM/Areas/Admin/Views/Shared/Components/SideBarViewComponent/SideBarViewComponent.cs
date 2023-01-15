using Microsoft.AspNetCore.Mvc;

namespace CHOM.Areas.Admin.Views.Shared.Components.SideBarViewComponent
{
    public class SideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
