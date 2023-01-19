using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VideoController : Controller
    {
        private readonly CHOMContext _db;
        public VideoController(CHOMContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.Videos.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _db.Videos.SingleOrDefault(x => x.ID == int.Parse(id));
                return View(model);
            }
            catch (Exception ex)
            {
                return Redirect("/Admin/Contact");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Video video,IFormFile? newVideo)
        {
            if (!ModelState.IsValid) return View(video);
            try
            {
                if (newVideo != null)
                {
                    if (video.FileName != newVideo.FileName)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", video.FileName);
                        System.IO.File.Delete(path);
                        string fileName = newVideo.FileName;
                        fileName = Path.GetFileName(fileName);
                        string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", fileName);
                        var stream = new FileStream(uploadPaths, FileMode.Create);
                        await newVideo.CopyToAsync(stream);
                        stream.Dispose();
                        video.FileName = newVideo.FileName;
                    }
                }
                _db.Attach(video);
                _db.Entry(video).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Video");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "chỉnh sửa liên hệ thất bại";
                return View(video);
            }
        }
    }
}
