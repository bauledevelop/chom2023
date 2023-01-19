using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ImageController : Controller
    {
        private readonly CHOMContext _db;

        public ImageController(CHOMContext db)
        {
            _db = db;
        }
        public IActionResult Index(string id)
        {
            var model = _db.HinhAnhs.Where(x => x.IDDuAn == int.Parse(id)).OrderByDescending(x => x.ID).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ListProject = new SelectList(_db.DuAns.ToList(),"ID", "TuaDe");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(List<IFormFile>? uploadFile, HinhAnh hinhanh)
        {
            ViewBag.ListProject = new SelectList(_db.DuAns.ToList(), "ID", "TuaDe",hinhanh.IDDuAn);
            if (uploadFile.Count() == 0)
            {
                ViewBag.Message = "Vui lòng chọn hình ảnh";
                return View(hinhanh);
            }
            if (!ModelState.IsValid) return View(hinhanh);
            try
            {
                foreach(var item in uploadFile)
                {
                    string fileName = item.FileName;
                    fileName = Path.GetFileName(fileName);
                    string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", fileName);
                    var stream = new FileStream(uploadPaths, FileMode.Create);
                    await item.CopyToAsync(stream);
                    stream.Dispose();
                    var newImage = new HinhAnh();
                    newImage.FileName = item.FileName;
                    newImage.IDDuAn = hinhanh.IDDuAn;
                    await _db.HinhAnhs.AddAsync(newImage);
                    await _db.SaveChangesAsync();
                }
                var link = "/Admin/Image/Index/" + hinhanh.IDDuAn;
                return Redirect(link);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Tạo hình ảnh thất bại";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _db.HinhAnhs.Find(int.Parse(id));
                ViewBag.ListProject = new SelectList(_db.DuAns.ToList(), "ID", "TuaDe", model.IDDuAn);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile newFile,HinhAnh hinhanh)
        {
            ViewBag.ListProject = new SelectList(_db.DuAns.ToList(), "ID", "TuaDe", hinhanh.IDDuAn);

            if (!ModelState.IsValid) return View(hinhanh);
            try
            {
                if (newFile != null)
                {
                    if (newFile.FileName != hinhanh.FileName)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", hinhanh.FileName);
                        System.IO.File.Delete(path);
                        string fileName = newFile.FileName;
                        fileName = Path.GetFileName(fileName);
                        string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", fileName);
                        var stream = new FileStream(uploadPaths, FileMode.Create);
                        await newFile.CopyToAsync(stream);
                        stream.Dispose();
                        hinhanh.FileName = newFile.FileName;
                    }
                }
                _db.Attach(hinhanh);
                _db.Entry(hinhanh).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                var link = "/Admin/Image/Index/" + hinhanh.IDDuAn;
                return Redirect(link);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Chỉnh sửa hình ảnh thất bại";
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var check = await _db.HinhAnhs.SingleOrDefaultAsync(x => x.ID == int.Parse(id));
                if (check != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", check.FileName);
                    System.IO.File.Delete(path);
                    _db.HinhAnhs.Remove(check);
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
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", deleteFile);
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
                string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", fileName);
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
