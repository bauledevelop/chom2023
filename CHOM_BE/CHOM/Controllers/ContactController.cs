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
            try
            {
                ViewBag.Contact = _db.Contacts.FirstOrDefault(x => x.ID == 1);
                ViewBag.LienHe = _db.LienHes.ToList();
                return View();
            }
            catch(Exception ex)
            {
                return Redirect("/404");
            }
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
                    phanHoi.YeuCau = "kiến trúc nội thất";
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
                var checkSendMail = await _emailSender.SendMail(mailContent);
                if (checkSendMail == false)
                {
                    ViewBag.Message = "Gửi phản hồi thất bại";
                    return View(phanHoi);
                }
                phanHoi.CreatedDate = DateTime.Now;
                _db.PhanHois.Add(phanHoi);
                await _db.SaveChangesAsync();
                ModelState.Clear();
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
