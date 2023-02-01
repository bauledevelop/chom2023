using CHOM.Data;
using CHOM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Mvc.Entensions;

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
            string idProject = id;
            HttpContext.Session.Set<string>("IDProject", idProject);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var getIdProject = HttpContext.Session.Get<string>("IDProject");
            if (getIdProject == null)
            {
                return Redirect("/Admin/Project");
            }
            else
            {
                ViewBag.IDProject = getIdProject;
                ViewBag.ListProject = new SelectList(_db.DuAns.ToList(), "ID", "TuaDe");
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(List<IFormFile>? uploadFile, HinhAnh hinhanh)
        {
            ViewBag.IDProject = HttpContext.Session.Get<string>("IDProject");
            ViewBag.ListProject = new SelectList(_db.DuAns.ToList(), "ID", "TuaDe", hinhanh.IDDuAn);
            if (uploadFile.Count() == 0)
            {
                ViewBag.Message = "Vui lòng chọn hình ảnh";
                return View(hinhanh);
            }
            if (!ModelState.IsValid) return View(hinhanh);
            try
            {
                foreach (var item in uploadFile)
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
                var getIdProject = HttpContext.Session.Get<string>("IDProject");
                if (getIdProject == null)
                {
                    return Redirect("/Admin/Project");
                }
                ViewBag.IDProject = getIdProject;
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
        public async Task<IActionResult> Edit(IFormFile newFile, HinhAnh hinhanh)
        {
            ViewBag.ListProject = new SelectList(_db.DuAns.ToList(), "ID", "TuaDe", hinhanh.IDDuAn);
            ViewBag.IDProject = HttpContext.Session.Get<string>("IDProject");
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
        public async Task<JsonResult> AddImage(IFormFile File)
        {
            try
            {
                var image = HttpContext.Session.Get<string>("image");
                if (image != null)
                {
                    if (await _db.DuAns.SingleOrDefaultAsync(x => x.HinhGT == image) == null)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", image);
                        System.IO.File.Delete(path);
                    }
                }
                int indexof = File.FileName.IndexOf('.');
                string fileName = "duan" + Guid.NewGuid().ToString() + '.' + File.FileName.Substring(indexof+1);
                string newName = fileName;
                fileName = Path.GetFileName(fileName);
                string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", fileName);
                var stream = new FileStream(uploadPaths, FileMode.Create);
                await File.CopyToAsync(stream);
                stream.Dispose();
                image = newName;
                HttpContext.Session.Set<string>("image", image);
                ViewBag.UploadFile = null;
                return Json(new
                {
                    status = true,
                    fileName = newName
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
        public async Task<JsonResult> DeleteImage(string filename)
        {
            try
            {
                var check = await _db.HinhAnhs.SingleOrDefaultAsync(x => x.FileName == filename);
                if (check == null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", filename);
                    System.IO.File.Delete(path);
                }
                return Json(new
                {
                    status = true
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex
                });
            }
        }
        [HttpPost]
        public async Task<JsonResult> DeleteMulFile(string id,string filename)
        {
            try
            {
                var listImage = HttpContext.Session.Get<List<ImageModel>>("ListImage");
                foreach (var item in listImage)
                {
                    if (item.id == id)
                    {
                        listImage.Remove(item);
                        break;
                    }
                }
                var check = _db.HinhAnhs.Where(x => x.FileName == filename);
                if (check.Count() == 0 && listImage.Where(x => x.image == filename).Count() == 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", filename);
                    System.IO.File.Delete(path);
                }
                
                HttpContext.Session.Set<List<ImageModel>>("ListImage",listImage);
                return Json(new
                {
                    status = true,
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex
                });
            }
        }
        [HttpPost]
        public async Task<JsonResult> AddMulImage(List<IFormFile> files)
        {
            try
            {

                var listImage = HttpContext.Session.Get<List<ImageModel>>("ListImage");
                if (listImage == null)
                {
                    listImage = new List<ImageModel>();
                }
                var images = new List<ImageModel>();
                foreach (var item in files)
                {
                    var _id = Guid.NewGuid().ToString();
                    int indexof = item.FileName.IndexOf('.');
                    string fileName = "hinhanh" + _id + "." + item.FileName.Substring(indexof + 1);
                    string newName = fileName;
                    fileName = Path.GetFileName(fileName);
                    string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", fileName);
                    var stream = new FileStream(uploadPaths, FileMode.Create);
                    await item.CopyToAsync(stream);
                    stream.Dispose();
                    var newImage = new ImageModel{
                        id = _id,
                        image = newName
                    };
                    listImage.Add(newImage);
                    images.Add(newImage);
                }
                HttpContext.Session.Set<List<ImageModel>>("ListImage", listImage);
                return Json(new
                {
                    status = true,
                    data = images,
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex
                });
            }
        }
    }
}
