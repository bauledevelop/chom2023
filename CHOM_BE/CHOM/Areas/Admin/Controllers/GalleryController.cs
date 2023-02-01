using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Mvc.Entensions;
using X.PagedList;

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
        public IActionResult Index(int page=1,int pageSize=16)
        {
            var model = _db.BoSuuTams.OrderByDescending(x => x.ID).Skip((page - 1)*pageSize).Take(pageSize).ToList();
            ViewBag.ListMenu = _db.MucLucs.ToList();
            ViewData["Pagination"] = _db.BoSuuTams.ToList().ToPagedList(page,pageSize);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 4).ToList(), "ID", "Ten");
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile uploadFile,BoSuuTam boSuuTam)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 4).ToList(), "ID", "Ten", boSuuTam.IDMucLuc);
            if (uploadFile == null)
            {
                ViewBag.Message = "Vui lòng chọn ảnh";
                return View(boSuuTam);
            }
            if (!ModelState.IsValid) return View(boSuuTam);
            try
            {
                int indexof = uploadFile.FileName.IndexOf('.');
                string fileName = "suutam" + Guid.NewGuid().ToString() + '.' + uploadFile.FileName.Substring(indexof + 1);
                boSuuTam.HinhAnh = fileName;
                fileName = Path.GetFileName(fileName);
                string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//imageGallery", fileName);
                var stream = new FileStream(uploadPaths, FileMode.Create);
                await uploadFile.CopyToAsync(stream);
                stream.Dispose();
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
            if (string.IsNullOrEmpty(id)) return Redirect("/Admin/Gallery");
            try
            {
                var model = _db.BoSuuTams.Find(int.Parse(id));
                ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 4).ToList(), "ID", "Ten", model.IDMucLuc);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile? newFile,BoSuuTam boSuuTam)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 4).AsNoTracking().ToList(), "ID", "Ten", boSuuTam.IDMucLuc);
            if (!ModelState.IsValid) return View(boSuuTam);
            try
            {
                if (newFile != null)
                {
                    if (newFile.FileName != boSuuTam.HinhAnh)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//imageGallery", boSuuTam.HinhAnh);
                        System.IO.File.Delete(path);
                        int indexof = newFile.FileName.IndexOf('.');
                        string fileName = "suutam" + Guid.NewGuid().ToString() + "." + newFile.FileName.Substring(indexof + 1);
                        boSuuTam.HinhAnh = fileName;
                        fileName = Path.GetFileName(fileName);
                        string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//imageGallery", fileName);
                        var stream = new FileStream(uploadPaths, FileMode.Create);
                        await newFile.CopyToAsync(stream);
                        stream.Dispose();

                    }
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
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//imageGallery", check.HinhAnh);
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
    }
}
