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
    public class TotalRotacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TotalRotacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TotalRotacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TotalRotacion.ToListAsync());
        }

        // GET: TotalRotacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalRotacion = await _context.TotalRotacion
                .FirstOrDefaultAsync(m => m.totalRotacionID == id);
            if (totalRotacion == null)
            {
                return NotFound();
            }

            return View(totalRotacion);
        }

        // GET: TotalRotacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TotalRotacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("totalRotacionID,invCosto,invVenta,pedidoCompra,backOrderTotal")] TotalRotacion totalRotacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalRotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(totalRotacion);
        }

        // GET: TotalRotacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalRotacion = await _context.TotalRotacion.FindAsync(id);
            if (totalRotacion == null)
            {
                return NotFound();
            }
            return View(totalRotacion);
        }

        // POST: TotalRotacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("totalRotacionID,invCosto,invVenta,pedidoCompra,backOrderTotal")] TotalRotacion totalRotacion)
        {
            if (id != totalRotacion.totalRotacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalRotacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalRotacionExists(totalRotacion.totalRotacionID))
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
            return View(totalRotacion);
        }

        // GET: TotalRotacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalRotacion = await _context.TotalRotacion
                .FirstOrDefaultAsync(m => m.totalRotacionID == id);
            if (totalRotacion == null)
            {
                return NotFound();
            }

            return View(totalRotacion);
        }

        // POST: TotalRotacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var totalRotacion = await _context.TotalRotacion.FindAsync(id);
            _context.TotalRotacion.Remove(totalRotacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalRotacionExists(int id)
        {
            return _context.TotalRotacion.Any(e => e.totalRotacionID == id);
        }
    }
}
