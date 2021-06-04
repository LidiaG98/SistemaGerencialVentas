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
    public class PuestoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PuestoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Puestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Puesto.ToListAsync());
        }

        // GET: Puestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puesto
                .FirstOrDefaultAsync(m => m.puestoID == id);
            if (puesto == null)
            {
                return NotFound();
            }

            return View(puesto);
        }

        // GET: Puestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("puestoID,nombrePuesto")] Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puesto);
        }

        // GET: Puestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puesto.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }
            return View(puesto);
        }

        // POST: Puestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("puestoID,nombrePuesto")] Puesto puesto)
        {
            if (id != puesto.puestoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoExists(puesto.puestoID))
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
            return View(puesto);
        }

        // GET: Puestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puesto = await _context.Puesto
                .FirstOrDefaultAsync(m => m.puestoID == id);
            if (puesto == null)
            {
                return NotFound();
            }

            return View(puesto);
        }

        // POST: Puestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puesto = await _context.Puesto.FindAsync(id);
            _context.Puesto.Remove(puesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoExists(int id)
        {
            return _context.Puesto.Any(e => e.puestoID == id);
        }
    }
}
