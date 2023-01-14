using CHOM.Data;
using Microsoft.AspNetCore.Mvc;

namespace CHOM.Views.Shared.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly CHOMContext _db;
        public HeaderViewComponent(CHOMContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.ListProject = _db.MucLucs.OrderBy(x => x.ID).ToList();
            return View();
        }
    }
}
