using CHOM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly CHOMContext _dbContext;

        public MenuController(CHOMContext dbContext)
        {
            _dbContext = dbContext;
        }
           
        public IActionResult Index()
        {
            try
            {
                var model = _dbContext.MucLucs.ToList();
                return View(model);
            }
            catch(Exception e)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var listMenu = _dbContext.MucLucs.ToList();
                var menu = new MucLuc
                {
                    ID = 0,
                    Ten = "Không thuộc mục lục"
                };
                listMenu.Insert(0, menu);
                ViewBag.ListMenu = new SelectList(listMenu, "ID", "Ten");
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(MucLuc mucLuc)
        {
            var listMenu = _dbContext.MucLucs.ToList();
            var menu = new MucLuc
            {
                ID = 0,
                Ten = "Không thuộc mục lục"
            };
            listMenu.Insert(0, menu);
            ViewBag.ListMenu = new SelectList(listMenu, "ID", "Ten",mucLuc.IDParent);
            if (!ModelState.IsValid) return View(mucLuc);
            try
            {
                await _dbContext.MucLucs.AddAsync(mucLuc);
                await _dbContext.SaveChangesAsync();
                return Redirect("/Admin/Menu");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Tạo mục lục thất bại";
            }
            return View(mucLuc);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _dbContext.MucLucs.Find(int.Parse(id));
                var listMenu = _dbContext.MucLucs.Where(x => x.ID != model.ID).ToList();
                var menu = new MucLuc
                {
                    ID = 0,
                    Ten = "Không thuộc mục lục"
                };
                listMenu.Insert(0, menu);
                ViewBag.ListMenu = new SelectList(listMenu, "ID", "Ten",model.IDParent);

                return View(model);
            }
            catch(Exception)
            {
                return Redirect("/Admin/Menu");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MucLuc mucLuc)
        {
            var listMenu = _dbContext.MucLucs.AsNoTracking().ToList();
            var menu = new MucLuc
            {
                ID = 0,
                Ten = "Không thuộc mục lục"
            };
            listMenu.Insert(0, menu);
            ViewBag.ListMenu = new SelectList(listMenu, "ID", "Ten", mucLuc.IDParent);
            if (!ModelState.IsValid) return View(mucLuc);
            try
            {
                _dbContext.MucLucs.Attach(mucLuc);
                _dbContext.Entry(mucLuc).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return Redirect("/Admin/Menu");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Thay đổi mục lục thất bại";
            }
            return View(mucLuc);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var check = await _dbContext.MucLucs.SingleOrDefaultAsync(x => x.ID == int.Parse(id));
                if (check != null)
                {
                    _dbContext.MucLucs.Remove(check);
                    await _dbContext.SaveChangesAsync();
                    return Json(new {
                        status = true
                    });
                }
            }
            catch(Exception ex)
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
