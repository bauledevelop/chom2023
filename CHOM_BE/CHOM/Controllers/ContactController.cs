using CHOM.Data;
using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class ContactController : Controller
    {
        private readonly CHOMContext _db;
        public ContactController(CHOMContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //ViewBag.About = _db.Abouts.SingleOrDefault(x => x.ID != 0);
            //var model = _db.DoiNgus.ToList();
            //ViewBag.LienHe = _db.LienHes.ToList();
            ViewBag.Contact = _db.Contacts.FirstOrDefault(x => x.ID == 1);
            ViewBag.LienHe = _db.LienHes.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(PhanHoi phanHoi)
        {
            ViewBag.Contact = _db.Contacts.FirstOrDefault(x => x.ID == 1);
            ViewBag.LienHe = _db.LienHes.ToList();
            if (!ModelState.IsValid) return View(phanHoi);
            if (phanHoi.YeuCau == "1")
            {
                phanHoi.YeuCau = "Kiến trúc cảnh quan";
            }
            else
            {
                if (phanHoi.YeuCau == "2")
                {
                    phanHoi.YeuCau = "Kiến trúc nội thất";
                }
                else
                {
                    if (phanHoi.YeuCau == "3")
                    {
                        phanHoi.YeuCau = "Kiến trúc thiết kế";
                    }
                    else
                    {
                        phanHoi.YeuCau = "Sai yêu cầu";
                    }
                }
            }
            try
            {
                phanHoi.CreatedDate = DateTime.Now;
                _db.PhanHois.Add(phanHoi);
                await _db.SaveChangesAsync();
                ViewBag.Success = "Gủi phản hồi thành công";
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Gửi phản hồi thất bại";
                return View(phanHoi);
            }
        }
    }
}
