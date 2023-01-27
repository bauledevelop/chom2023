using CHOM.Data;
using CHOM.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CHOM.Controllers
{
    public class ContactController : Controller
    {
        private readonly CHOMContext _db;
        private readonly IEmailSender _emailSender;
        public ContactController(CHOMContext db, IEmailSender emailSender)
        {
            _db = db;
            _emailSender = emailSender;
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
                phanHoi.YeuCau = "Landscape architecture";
            }
            else
            {
                if (phanHoi.YeuCau == "2")
                {
                    phanHoi.YeuCau = "Interior architecture";
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
                var mailContent = new MailContent();
                var emailAdmin = _db.LienHes.SingleOrDefault(x => x.PhuongThuc == "Email");
                mailContent.To = emailAdmin.Ten;
                mailContent.Subject = "Phản hồi đến từ khách hàng";
                string content = string.Empty;
                using (StreamReader reader = new StreamReader(Path.Combine("assets/template/Feedback.html")))
                {
                    content = reader.ReadToEnd();
                }
                content = content.Replace("{{CustomerName}}", phanHoi.Email);
                content = content.Replace("{{Email}}", phanHoi.Email);
                content = content.Replace("{{Name}}", phanHoi.Ten);
                content = content.Replace("{{Phone}}", phanHoi.SDT);
                content = content.Replace("{{Request}}", phanHoi.YeuCau);
                content = content.Replace("{{Content}}", phanHoi.NoiDung);
                mailContent.Body = content;
                await _emailSender.SendMail(mailContent);
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
