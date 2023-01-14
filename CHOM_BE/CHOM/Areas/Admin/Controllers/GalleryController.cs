using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly CHOMContext _db;
        public GalleryController(CHOMContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.BoSuuTams.ToList();
            ViewBag.ListMenu = _db.MucLucs.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.Ten == "Gallery").ToList(), "ID", "Ten");
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(BoSuuTam boSuuTam)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.Ten == "Gallery").ToList(), "ID", "Ten", boSuuTam.IDMucLuc);
            if (!ModelState.IsValid) return View(boSuuTam);
            try
            {
                boSuuTam.NgayTao = DateTime.Now;
                await _db.AddAsync(boSuuTam);
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Gallery");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Tạo bộ sưu tầm thất bại";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _db.BoSuuTams.Find(int.Parse(id));
                ViewBag.ListMenu = new SelectList(_db.MucLucs.ToList(), "ID", "Ten", model.IDMucLuc);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BoSuuTam boSuuTam,string? newFile)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.Ten == "Gallery").AsNoTracking().ToList(), "ID", "Ten", boSuuTam.IDMucLuc);
            if (!ModelState.IsValid) return View(boSuuTam);
            try
            {
                if (newFile != boSuuTam.HinhAnh && newFile != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", boSuuTam.HinhAnh);
                    System.IO.File.Delete(path);
                    boSuuTam.HinhAnh = newFile;
                }
                _db.Attach(boSuuTam);
                _db.Entry(boSuuTam).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Gallery");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Chỉnh sửa bộ sưu tầm không thành công";
                return View();
            }
        }
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var check = await _db.BoSuuTams.SingleOrDefaultAsync(x => x.ID == int.Parse(id));
                if (check != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", check.HinhAnh);
                    System.IO.File.Delete(path);
                    _db.BoSuuTams.Remove(check);
                    await _db.SaveChangesAsync();
                    return Json(new
                    {
                        status = true
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }
            return Json(new
            {
                status = false
            });
        }
        [HttpPost]
        public async Task<JsonResult> DeleteImage(string deleteFile)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", deleteFile);
                System.IO.File.Delete(path);
                return Json(new
                {
                    status = true,
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

        [HttpPost]
        public async Task<JsonResult> AddImage(IFormFile File)
        {
            if (File == null)
            {
                return Json(new
                {
                    status = false,
                    message = "Vui lòng chọn file ảnh trước khi tải"
                });
            }
            try
            {
                string fileName = File.FileName;
                fileName = Path.GetFileName(fileName);
                string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", fileName);
                var stream = new FileStream(uploadPaths, FileMode.Create);
                await File.CopyToAsync(stream);
                stream.Dispose();
                ViewBag.UploadFile = null;
                return Json(new
                {
                    status = true,
                    fileName = File.FileName
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}
