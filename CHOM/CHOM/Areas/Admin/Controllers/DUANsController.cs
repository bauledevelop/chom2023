using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHOM.Data;

namespace CHOM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DUANsController : Controller
    {
        private readonly CHOMContext _context;

        public DUANsController(CHOMContext context)
        {
            _context = context;
        }

        // GET: Admin/DUANs
        public async Task<IActionResult> Index()
        {
            var cHOMContext = _context.DUAN.Include(d => d.THUVIENs);
            return View(await cHOMContext.ToListAsync());
        }

        // GET: Admin/DUANs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DUAN == null)
            {
                return NotFound();
            }

            var dUAN = await _context.DUAN
                .Include(d => d.THUVIENs)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dUAN == null)
            {
                return NotFound();
            }

            return View(dUAN);
        }

        // GET: Admin/DUANs/Create
        public IActionResult Create()
        {
            ViewData["MaThuVien"] = new SelectList(_context.THUVIEN, "ID", "TUADE");
            return View();
        }

        // POST: Admin/DUANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TUADE,HINHGT,NOIDUNG,MaThuVien")] DUAN dUAN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dUAN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaThuVien"] = new SelectList(_context.THUVIEN, "ID", "TUADE", dUAN.MaThuVien);
            return View(dUAN);
        }

        // GET: Admin/DUANs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DUAN == null)
            {
                return NotFound();
            }

            var dUAN = await _context.DUAN.FindAsync(id);
            if (dUAN == null)
            {
                return NotFound();
            }
            ViewData["MaThuVien"] = new SelectList(_context.THUVIEN, "ID", "TUADE", dUAN.MaThuVien);
            return View(dUAN);
        }

        // POST: Admin/DUANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TUADE,HINHGT,NOIDUNG,MaThuVien")] DUAN dUAN)
        {
            if (id != dUAN.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dUAN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DUANExists(dUAN.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaThuVien"] = new SelectList(_context.THUVIEN, "ID", "TUADE", dUAN.MaThuVien);
            return View(dUAN);
        }

        // GET: Admin/DUANs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DUAN == null)
            {
                return NotFound();
            }

            var dUAN = await _context.DUAN
                .Include(d => d.THUVIENs)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dUAN == null)
            {
                return NotFound();
            }

            return View(dUAN);
        }

        // POST: Admin/DUANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DUAN == null)
            {
                return Problem("Entity set 'CHOMContext.DUAN'  is null.");
            }
            var dUAN = await _context.DUAN.FindAsync(id);
            if (dUAN != null)
            {
                _context.DUAN.Remove(dUAN);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DUANExists(int id)
        {
          return _context.DUAN.Any(e => e.ID == id);
        }
    }
}
