using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StaffController : Controller
    {
        private readonly CHOMContext _db;
        public StaffController(CHOMContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.DoiNgus.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoiNgu doiNgu)
        {
            if (!ModelState.IsValid) return View(doiNgu);
            try
            {
                await _db.DoiNgus.AddAsync(doiNgu);
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Staff");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Tạo nhân viên thất bại";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _db.DoiNgus.Find(int.Parse(id));
                return View(model);
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DoiNgu doiNgu, string? newFile)
        {
            if (!ModelState.IsValid) return View(doiNgu);
            try
            {
                if (newFile != doiNgu.HinhAnh && newFile != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", doiNgu.HinhAnh);
                    System.IO.File.Delete(path);
                    doiNgu.HinhAnh = newFile;
                }
                _db.Attach(doiNgu);
                _db.Entry(doiNgu).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Staff");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Chỉnh sửa nhân viên thất bại";
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var check = await _db.DoiNgus.SingleOrDefaultAsync(x => x.ID == int.Parse(id));
                if (check != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", check.HinhAnh);
                    System.IO.File.Delete(path);
                    _db.DoiNgus.Remove(check);
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
            catch (Exception ex)
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
