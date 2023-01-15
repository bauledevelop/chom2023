using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly CHOMContext _db;
        public ProjectController(CHOMContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.DuAns.ToList();
            ViewBag.ListHinhAnh = _db.HinhAnhs.ToList();
            ViewBag.ListMenu = _db.MucLucs.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.Ten == "Landscape" || x.Ten == "Interior").ToList(),"ID","Ten");
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(DuAn duAn, List<IFormFile> uploadFiles)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.Ten == "Landscape" || x.Ten == "Interior").ToList(), "ID", "Ten",duAn.IDMucLuc);
            if (!ModelState.IsValid) return View(duAn);
            try
            {
                await _db.DuAns.AddAsync(duAn);
                await _db.SaveChangesAsync();
                foreach(var file in uploadFiles)
                {
                    string fileName = file.FileName;
                    fileName = Path.GetFileName(fileName);
                    string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", fileName);
                    var stream = new FileStream(uploadPaths, FileMode.Create);
                    await file.CopyToAsync(stream);
                    stream.Dispose();
                    var hinhanh = new HinhAnh();
                    hinhanh.FileName = file.FileName;
                    hinhanh.IDDuAn = duAn.ID;
                    await _db.AddAsync(hinhanh);
                    await _db.SaveChangesAsync();
                }
                return Redirect("/Admin/Project");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _db.DuAns.Find(int.Parse(id));
                ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.Ten == "Landscape" || x.Ten == "Interior").ToList(), "ID", "Ten", model.IDMucLuc);
                return View(model);
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DuAn duAn, List<IFormFile> mulFile, string? newFile)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.Ten == "Landscape" || x.Ten == "Interior").ToList(), "ID", "Ten", duAn.IDMucLuc);
            if (!ModelState.IsValid) return View(duAn);
            try
            {
                if (mulFile.Count() > 0)
                {
                    var hinhAnhs = _db.HinhAnhs.Where(x => x.IDDuAn == duAn.ID).ToList();
                    if (hinhAnhs.Count() > 0)
                    {
                        foreach (var item in hinhAnhs)
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", item.FileName);
                            System.IO.File.Delete(path);
                            _db.Remove(item);
                            await _db.SaveChangesAsync();
                        }
                    }
                    foreach (var file in mulFile)
                    {
                        string fileName = file.FileName;
                        fileName = Path.GetFileName(fileName);
                        string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", fileName);
                        var stream = new FileStream(uploadPaths, FileMode.Create);
                        await file.CopyToAsync(stream);
                        stream.Dispose();
                        var hinhanh = new HinhAnh();
                        hinhanh.FileName = file.FileName;
                        hinhanh.IDDuAn = duAn.ID;
                        await _db.AddAsync(hinhanh);
                        await _db.SaveChangesAsync();
                    }
                }
                if (newFile != duAn.HinhGT && newFile != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", duAn.HinhGT);
                    System.IO.File.Delete(path);
                    duAn.HinhGT = newFile;
                }
                _db.ChangeTracker.Clear();
                _db.Attach(duAn);
                _db.Entry(duAn).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Redirect("/Admin/Project");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Thay đổi dự án thất bại";
                return View();
            }
        }
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var check = await _db.DuAns.SingleOrDefaultAsync(x => x.ID == int.Parse(id));
                if (check != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", check.HinhGT);
                    System.IO.File.Delete(path);
                    var listHinhAnh = _db.HinhAnhs.Where(x => x.IDDuAn == int.Parse(id));
                    foreach(var item in listHinhAnh)
                    {
                        string pathImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", item.FileName);
                        System.IO.File.Delete(pathImage);
                    }
                    _db.DuAns.Remove(check);
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
