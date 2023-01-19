using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly CHOMContext _db;
        public ContactController(CHOMContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.Contacts.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _db.Contacts.SingleOrDefault(x => x.ID == int.Parse(id));
                return View(model);
            }
            catch(Exception ex)
            {
                return Redirect("/Admin/Contact");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile? newFile, Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            try
            {
                if (newFile != null)
                {
                    if (newFile.FileName != contact.HinhAnh)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", contact.HinhAnh);
                        System.IO.File.Delete(path);
                        string fileName = newFile.FileName;
                        fileName = Path.GetFileName(fileName);
                        string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", fileName);
                        var stream = new FileStream(uploadPaths, FileMode.Create);
                        await newFile.CopyToAsync(stream);
                        stream.Dispose();
                        contact.HinhAnh = newFile.FileName;
                    }
                }
                _db.Attach(contact);
                _db.Entry(contact).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Contact");

            }
            catch (Exception ex)
            {
                ViewBag.Message = "chỉnh sửa liên hệ thất bại";
                return View(contact);
            }
        }
    }
}
