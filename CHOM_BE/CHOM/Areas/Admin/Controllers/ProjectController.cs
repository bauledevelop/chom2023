using CHOM.Data;
using CHOM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using Shop.Mvc.Entensions;

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
        public async Task<IActionResult> Index()
        {
            var image = HttpContext.Session.Get<string>("image");
            var listImage = HttpContext.Session.Get<List<ImageModel>>("ListImage");
            if (image != null)
            {
                if (_db.DuAns.Where(x => x.HinhGT == image).Count() == 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", image);
                    System.IO.File.Delete(path);
                }
                image = null;
                HttpContext.Session.Set<string>("image", image);
            }
            if (listImage == null)
            {
                listImage = new List<ImageModel>();
            }
            else
            {
                if (listImage.Count > 0)
                {
                    foreach (var item in listImage)
                    {
                        if (_db.HinhAnhs.Where(x => x.FileName == item.image).Count() == 0)
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", item.image);
                            System.IO.File.Delete(path);
                        }
                    }
                    listImage = new List<ImageModel>();
                }
            }
            HttpContext.Session.Set<List<ImageModel>>("ListImage", listImage);
            var model = _db.DuAns.OrderByDescending(x => x.ID).ToList();
            ViewBag.ListMenu = _db.MucLucs.ToList();
            ViewBag.ListHinhAnh = _db.HinhAnhs.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var image = HttpContext.Session.Get<string>("image");
            var listImage = HttpContext.Session.Get<List<ImageModel>>("ListImage");
            if (image != null)
            {
                if (_db.DuAns.Where(x => x.HinhGT == image).Count() == 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", image);
                    System.IO.File.Delete(path);
                }
                image = null;
                HttpContext.Session.Set<string>("image", image);
            }
            if (listImage == null)
            {
                listImage = new List<ImageModel>();
            }
            else
            {
                if (listImage.Count > 0)
                {
                    foreach (var item in listImage)
                    {
                        if (_db.HinhAnhs.Where(x => x.FileName == item.image).Count() == 0)
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", item.image);
                            System.IO.File.Delete(path);
                        }
                    }
                    listImage = new List<ImageModel>();
                }
            }
            HttpContext.Session.Set<List<ImageModel>>("ListImage", listImage);
            try
            {
                ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 2 || x.ID == 3).ToList(),"ID","Ten");
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(DuAn duAn)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 2 || x.ID == 3).ToList(), "ID", "Ten",duAn.IDMucLuc);
            var image = HttpContext.Session.Get<string>("image");
            var listImage = HttpContext.Session.Get<List<ImageModel>>("ListImage");
            if (image == null)
            {
                ViewBag.Message = "Vui lòng chọn hình ảnh giới thiệu";
                listImage = new List<ImageModel>();
                HttpContext.Session.Set<List<ImageModel>>("ListImage",listImage);
                return View(duAn);
            }
            if (listImage.Count == 0)
            {
                ViewBag.Message = "Vui lòng chọn hình ảnh dự án";
                image = null;
                HttpContext.Session.Set<string>("image", image);
                return View(duAn);
            }
            if (!ModelState.IsValid) return View(duAn);
            try
            {
                var check = await _db.DuAns.SingleOrDefaultAsync(x => x.TuaDe == duAn.TuaDe);
                if (check != null)
                {
                    ViewBag.Message = "Dự án đã tồn tại";
                    listImage = new List<ImageModel>();
                    HttpContext.Session.Set<List<ImageModel>>("ListImage", listImage);
                    image = null;
                    HttpContext.Session.Set<string>("image", image);
                    return View(duAn);
                }
                duAn.HinhGT = image;
                await _db.AddAsync(duAn);
                await _db.SaveChangesAsync();
                image = null;
                HttpContext.Session.Set<string>("image", image);
                foreach (var item in listImage)
                {
                    var hinhanh = new HinhAnh();
                    hinhanh.FileName = item.image;
                    hinhanh.IDDuAn = duAn.ID;
                    await _db.HinhAnhs.AddAsync(hinhanh);
                    await _db.SaveChangesAsync();
                }
                listImage = new List<ImageModel>();
                HttpContext.Session.Set<List<ImageModel>>("ListImage", listImage);
                return Redirect("/Admin/Project");

            }
            catch(Exception ex)
            {
                ViewBag.Message = "Thêm hình thất bại";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var image = HttpContext.Session.Get<string>("image");
            var listImage = HttpContext.Session.Get<List<ImageModel>>("ListImage");
            if (image != null)
            {
                if (_db.DuAns.Where(x => x.HinhGT == image).Count() == 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", image);
                    System.IO.File.Delete(path);
                }
                image = null;
            }
            if (listImage == null)
            {
                listImage = new List<ImageModel>();
            }
            else
            {
                if (listImage.Count > 0)
                {
                    foreach (var item in listImage)
                    {
                        if (_db.HinhAnhs.Where(x => x.FileName == item.image).Count() == 0)
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", item.image);
                            System.IO.File.Delete(path);
                        }
                    }
                    listImage = new List<ImageModel>();
                }
            }
            HttpContext.Session.Set<string>("image", image);
            if (string.IsNullOrEmpty(id)) return Redirect("/Admin/Project");
            try
            {
                var model = _db.DuAns.Find(int.Parse(id));
                ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 2 || x.ID == 3).ToList(), "ID", "Ten", model.IDMucLuc);
                var listImageData = _db.HinhAnhs.Where(x => x.IDDuAn == model.ID);
                foreach(var item in listImageData)
                {
                    listImage.Add(new ImageModel
                    {
                        id = Guid.NewGuid().ToString(),
                        image = item.FileName
                    });
                }
                ViewBag.ListImage = listImage;
                HttpContext.Session.Set<List<ImageModel>>("ListImage", listImage);
                return View(model);
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DuAn duAn)
        {
            ViewBag.ListMenu = new SelectList(_db.MucLucs.Where(x => x.ID == 2 || x.ID == 3).ToList(), "ID", "Ten", duAn.IDMucLuc).ToList();
            var image = HttpContext.Session.Get<string>("image");
            var listImage = HttpContext.Session.Get<List<ImageModel>>("ListImage");
            if (listImage.Count() == 0)
            {
                if (image != null)
                {
                    if (image != duAn.HinhGT)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", image);
                        System.IO.File.Delete(path);
                        image = null;
                        HttpContext.Session.Set<string>("image", image);
                    }
                }
                ViewBag.Message = "Vui lòng không để trống hình dự án";
                var listImageData = _db.HinhAnhs.Where(x => x.IDDuAn == duAn.ID);
                foreach (var item in listImageData)
                {
                    listImage.Add(new ImageModel
                    {
                        id = Guid.NewGuid().ToString(),
                        image = item.FileName
                    });
                }
                ViewBag.ListImage = listImage;
                return View(duAn);
            }
            if (!ModelState.IsValid) return View(duAn);
            try
            {
                var check = _db.DuAns.SingleOrDefault(x => x.TuaDe == duAn.TuaDe && x.ID != duAn.ID);
                if (check != null)
                {
                    ViewBag.Message = "Dự án này đã tồn tại";
                    return View(duAn);
                }
                if (image != null)
                {
                    if (image != duAn.HinhGT)
                    {
                        var checkExistHinhGT = _db.DuAns.Where(x => x.HinhGT == duAn.HinhGT && x.ID != duAn.ID).ToList();
                        if (checkExistHinhGT.Count() == 0)
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", duAn.HinhGT);
                            System.IO.File.Delete(path);
                        }
                        duAn.HinhGT = image;
                    }
                }
                var listImageData = _db.HinhAnhs.Where(x => x.IDDuAn == duAn.ID).ToList();
                foreach(var item in listImageData)
                {
                    if (listImage.Where(x => x.image == item.FileName).Count() == 0 && _db.HinhAnhs.Where(x => x.IDDuAn != duAn.ID && x.FileName == item.FileName).ToList().Count() == 0)
                    {
                        var checkExistInProject = _db.HinhAnhs.Where(x => x.FileName == item.FileName).ToList();
                        if (checkExistInProject.Count() == 1)
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", item.FileName);
                            System.IO.File.Delete(path);
                        }
                    }
                    _db.HinhAnhs.Remove(item);
                    await _db.SaveChangesAsync();
                }
                foreach(var item in listImage)
                {
                    var hinhAnh = new HinhAnh();
                    hinhAnh.IDDuAn = duAn.ID;
                    hinhAnh.FileName = item.image;
                    await _db.AddAsync(hinhAnh);
                    await _db.SaveChangesAsync();
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
                    if (_db.DuAns.Where(x => x.ID != check.ID && x.HinhGT == check.HinhGT).Count() == 0)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploadFiles", check.HinhGT);
                        System.IO.File.Delete(path);
                    }
                    var listHinhAnh = _db.HinhAnhs.Where(x => x.IDDuAn == int.Parse(id));
                    foreach(var item in listHinhAnh)
                    {
                        if (_db.HinhAnhs.Where(x => x.FileName == item.FileName && x.IDDuAn != item.IDDuAn).Count() == 0)
                        {
                            string pathImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//fileImages", item.FileName);
                            System.IO.File.Delete(pathImage);
                        }
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
        public async Task<JsonResult> DeleteImageGT(string deleteFile)
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
            try
            {
                string fileName = File.FileName;
                fileName = Path.GetFileName(fileName);
                string uploadPaths = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", fileName);
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
