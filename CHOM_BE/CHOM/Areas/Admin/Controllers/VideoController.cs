using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Mvc.Entensions;

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
            var video = HttpContext.Session.Get<string>("newVideo");
            if (video != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", video);
                System.IO.File.Delete(path);
                video = null;
                HttpContext.Session.Set<string>("newVideo", video);

            }
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
                var newVideo = HttpContext.Session.Get<string>("newVideo");
                if (newVideo != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", newVideo);
                    System.IO.File.Delete(path);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return Redirect("/Admin/Contact");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Video video)
        {
            if (!ModelState.IsValid) return View(video);
            try
            {
                var newVideo = HttpContext.Session.Get<string>("newVideo");
                if (newVideo != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", video.FileName);
                    System.IO.File.Delete(path);
                    video.FileName = newVideo;
                    _db.Attach(video);
                    _db.Entry(video).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    newVideo = null;
                    HttpContext.Session.Set<string>("newVideo", newVideo);
                }
                return Redirect("/Admin/Video");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "chỉnh sửa liên hệ thất bại";
                return View(video);
            }
        }

        [HttpPost]
        public async Task<JsonResult> ChangeVideo(IFormFile? File)
        {
            try
            {
                var video = HttpContext.Session.Get<string>("newVideo");
                if (video != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", video);
                    System.IO.File.Delete(path);
                    video = null;
                }
                int indexof = File.FileName.IndexOf('.');
                string fileName = "video" + Guid.NewGuid().ToString() + "." + File.FileName.Substring(indexof + 1);
                video = fileName;
                fileName = Path.GetFileName(fileName);
                string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//contact", fileName);
                var stream = new FileStream(uploadPaths, FileMode.Create);
                await File.CopyToAsync(stream);
                stream.Dispose();
                HttpContext.Session.Set<string>("newVideo", video);
                return Json(new
                {
                    status = true,
                    data = video
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }
        }

    }
}
