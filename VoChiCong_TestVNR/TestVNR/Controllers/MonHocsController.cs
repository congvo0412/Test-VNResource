using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestVNR.Models;

namespace TestVNR.Controllers
{
    public class MonHocsController : Controller
    {
        private readonly VNR_InternShipContext _context;

        public MonHocsController(VNR_InternShipContext context)
        {
            _context = context;
        }

        // GET: MonHocs
        public async Task<IActionResult> Index()
        {
            var vNR_InternShipContext = _context.MonHoc.Include(m => m.KhoaHoc);
            return View(await vNR_InternShipContext.ToListAsync());
        }

        // GET: MonHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHoc
                .Include(m => m.KhoaHoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // GET: MonHocs/Create
        public IActionResult Create()
        {
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHoc, "Id", "Id");
            return View();
        }

        // POST: MonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenMonHoc,MoTa,KhoaHocId")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHoc, "Id", "Id", monHoc.KhoaHocId);
            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHoc.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHoc, "Id", "Id", monHoc.KhoaHocId);
            return View(monHoc);
        }

        // POST: MonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenMonHoc,MoTa,KhoaHocId")] MonHoc monHoc)
        {
            if (id != monHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonHocExists(monHoc.Id))
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
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHoc, "Id", "Id", monHoc.KhoaHocId);
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHoc
                .Include(m => m.KhoaHoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monHoc = await _context.MonHoc.FindAsync(id);
            _context.MonHoc.Remove(monHoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonHocExists(int id)
        {
            return _context.MonHoc.Any(e => e.Id == id);
        }
    }
}
