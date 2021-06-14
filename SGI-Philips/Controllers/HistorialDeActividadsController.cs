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
    public class HistorialDeActividadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistorialDeActividadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HistorialDeActividads
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistorialDeActividad.ToListAsync());
        }

        // GET: HistorialDeActividads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialDeActividad = await _context.HistorialDeActividad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialDeActividad == null)
            {
                return NotFound();
            }

            return View(historialDeActividad);
        }

        // GET: HistorialDeActividads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistorialDeActividads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("historialDeActividadID,tipoActividad,fechaCreación,fechaActualización,Id")] HistorialDeActividad historialDeActividad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialDeActividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historialDeActividad);
        }

        // GET: HistorialDeActividads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialDeActividad = await _context.HistorialDeActividad.FindAsync(id);
            if (historialDeActividad == null)
            {
                return NotFound();
            }
            return View(historialDeActividad);
        }

        // POST: HistorialDeActividads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("historialDeActividadID,tipoActividad,fechaCreación,fechaActualización,Id")] HistorialDeActividad historialDeActividad)
        {
            if (id != historialDeActividad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialDeActividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialDeActividadExists(historialDeActividad.Id))
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
            return View(historialDeActividad);
        }

        // GET: HistorialDeActividads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialDeActividad = await _context.HistorialDeActividad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialDeActividad == null)
            {
                return NotFound();
            }

            return View(historialDeActividad);
        }

        // POST: HistorialDeActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var historialDeActividad = await _context.HistorialDeActividad.FindAsync(id);
            _context.HistorialDeActividad.Remove(historialDeActividad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialDeActividadExists(string id)
        {
            return _context.HistorialDeActividad.Any(e => e.Id == id);
        }
    }
}
