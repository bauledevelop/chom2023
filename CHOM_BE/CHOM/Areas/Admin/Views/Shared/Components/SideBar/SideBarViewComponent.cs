using Microsoft.AspNetCore.Mvc;

namespace CHOM.Areas.Admin.Views.Shared.Components.SideBar
{
    public class SideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
