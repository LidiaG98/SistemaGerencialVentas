using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGI_Philips.Data;
using SGI_Philips.Models;

namespace SGI_Philips.Controllers
{
    public class RotacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RotacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rotacions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rotacion.Include(r => r.totalRotacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rotacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotacion = await _context.Rotacion
                .Include(r => r.totalRotacion)
                .FirstOrDefaultAsync(m => m.rotacionID == id);
            if (rotacion == null)
            {
                return NotFound();
            }

            return View(rotacion);
        }

        // GET: Rotacions/Create
        public IActionResult Create()
        {
            ViewData["totalrotacionID"] = new SelectList(_context.TotalRotacion, "totalRotacionID", "totalRotacionID");
            return View();
        }

        // POST: Rotacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rotacionID,tipo,mesesInv,totalrotacionID")] Rotacion rotacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["totalrotacionID"] = new SelectList(_context.TotalRotacion, "totalRotacionID", "totalRotacionID", rotacion.totalrotacionID);
            return View(rotacion);
        }

        // GET: Rotacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotacion = await _context.Rotacion.FindAsync(id);
            if (rotacion == null)
            {
                return NotFound();
            }
            ViewData["totalrotacionID"] = new SelectList(_context.TotalRotacion, "totalRotacionID", "totalRotacionID", rotacion.totalrotacionID);
            return View(rotacion);
        }

        // POST: Rotacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rotacionID,tipo,mesesInv,totalrotacionID")] Rotacion rotacion)
        {
            if (id != rotacion.rotacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rotacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotacionExists(rotacion.rotacionID))
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
            ViewData["totalrotacionID"] = new SelectList(_context.TotalRotacion, "totalRotacionID", "totalRotacionID", rotacion.totalrotacionID);
            return View(rotacion);
        }

        // GET: Rotacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotacion = await _context.Rotacion
                .Include(r => r.totalRotacion)
                .FirstOrDefaultAsync(m => m.rotacionID == id);
            if (rotacion == null)
            {
                return NotFound();
            }

            return View(rotacion);
        }

        // POST: Rotacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rotacion = await _context.Rotacion.FindAsync(id);
            _context.Rotacion.Remove(rotacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RotacionExists(int id)
        {
            return _context.Rotacion.Any(e => e.rotacionID == id);
        }
    }
}
