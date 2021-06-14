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
    public class ConsolidadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsolidadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consolidadoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consolidado.Include(c => c.Mes).Include(c => c.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consolidadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consolidado = await _context.Consolidado
                .Include(c => c.Mes)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.consolidadoID == id);
            if (consolidado == null)
            {
                return NotFound();
            }

            return View(consolidado);
        }

        // GET: Consolidadoes/Create
        public IActionResult Create()
        {
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID");
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID");
            return View();
        }

        // POST: Consolidadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("consolidadoID,anioConsolidado,ventasConsolidado,productoID,mesID")] Consolidado consolidado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consolidado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID", consolidado.mesID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", consolidado.productoID);
            return View(consolidado);
        }

        // GET: Consolidadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consolidado = await _context.Consolidado.FindAsync(id);
            if (consolidado == null)
            {
                return NotFound();
            }
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID", consolidado.mesID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", consolidado.productoID);
            return View(consolidado);
        }

        // POST: Consolidadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("consolidadoID,anioConsolidado,ventasConsolidado,productoID,mesID")] Consolidado consolidado)
        {
            if (id != consolidado.consolidadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consolidado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsolidadoExists(consolidado.consolidadoID))
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
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID", consolidado.mesID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", consolidado.productoID);
            return View(consolidado);
        }

        // GET: Consolidadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consolidado = await _context.Consolidado
                .Include(c => c.Mes)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.consolidadoID == id);
            if (consolidado == null)
            {
                return NotFound();
            }

            return View(consolidado);
        }

        // POST: Consolidadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consolidado = await _context.Consolidado.FindAsync(id);
            _context.Consolidado.Remove(consolidado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsolidadoExists(int id)
        {
            return _context.Consolidado.Any(e => e.consolidadoID == id);
        }
    }
}
