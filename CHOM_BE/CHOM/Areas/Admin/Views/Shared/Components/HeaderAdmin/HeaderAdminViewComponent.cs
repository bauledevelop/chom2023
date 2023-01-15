using Microsoft.AspNetCore.Mvc;

namespace CHOM.Areas.Admin.Views.Shared.Components
{
    public class HeaderAdminViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
