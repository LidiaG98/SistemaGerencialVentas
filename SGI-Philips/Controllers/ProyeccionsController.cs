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
    public class ProyeccionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProyeccionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proyeccions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proyeccion.Include(p => p.Mes).Include(p => p.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proyeccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyeccion = await _context.Proyeccion
                .Include(p => p.Mes)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.proyeccionID == id);
            if (proyeccion == null)
            {
                return NotFound();
            }

            return View(proyeccion);
        }

        // GET: Proyeccions/Create
        public IActionResult Create()
        {
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID");
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID");
            return View();
        }

        // POST: Proyeccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("proyeccionID,anioProyeccion,ventasProyeccion,productoID,mesID")] Proyeccion proyeccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID", proyeccion.mesID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", proyeccion.productoID);
            return View(proyeccion);
        }

        // GET: Proyeccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyeccion = await _context.Proyeccion.FindAsync(id);
            if (proyeccion == null)
            {
                return NotFound();
            }
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID", proyeccion.mesID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", proyeccion.productoID);
            return View(proyeccion);
        }

        // POST: Proyeccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("proyeccionID,anioProyeccion,ventasProyeccion,productoID,mesID")] Proyeccion proyeccion)
        {
            if (id != proyeccion.proyeccionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyeccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyeccionExists(proyeccion.proyeccionID))
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
            ViewData["mesID"] = new SelectList(_context.Mes, "mesID", "mesID", proyeccion.mesID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", proyeccion.productoID);
            return View(proyeccion);
        }

        // GET: Proyeccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyeccion = await _context.Proyeccion
                .Include(p => p.Mes)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.proyeccionID == id);
            if (proyeccion == null)
            {
                return NotFound();
            }

            return View(proyeccion);
        }

        // POST: Proyeccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyeccion = await _context.Proyeccion.FindAsync(id);
            _context.Proyeccion.Remove(proyeccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyeccionExists(int id)
        {
            return _context.Proyeccion.Any(e => e.proyeccionID == id);
        }
    }
}
