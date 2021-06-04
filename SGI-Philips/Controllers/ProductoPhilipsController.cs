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
    public class ProductoPhilipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoPhilipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductoPhilips
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductoPhilips.Include(p => p.CategoriaPhilips).Include(p => p.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductoPhilips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPhilips = await _context.ProductoPhilips
                .Include(p => p.CategoriaPhilips)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.productoPhilipsID == id);
            if (productoPhilips == null)
            {
                return NotFound();
            }

            return View(productoPhilips);
        }

        // GET: ProductoPhilips/Create
        public IActionResult Create()
        {
            ViewData["categoriaPhilipsID"] = new SelectList(_context.CategoriaPhilips, "categoriaPhilipsID", "categoriaPhilipsID");
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID");
            return View();
        }

        // POST: ProductoPhilips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productoPhilipsID,precio,codigoPhillips,descripcionPhillips,categoriaPhilipsID,productoID")] ProductoPhilips productoPhilips)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoPhilips);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoriaPhilipsID"] = new SelectList(_context.CategoriaPhilips, "categoriaPhilipsID", "categoriaPhilipsID", productoPhilips.categoriaPhilipsID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", productoPhilips.productoID);
            return View(productoPhilips);
        }

        // GET: ProductoPhilips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPhilips = await _context.ProductoPhilips.FindAsync(id);
            if (productoPhilips == null)
            {
                return NotFound();
            }
            ViewData["categoriaPhilipsID"] = new SelectList(_context.CategoriaPhilips, "categoriaPhilipsID", "categoriaPhilipsID", productoPhilips.categoriaPhilipsID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", productoPhilips.productoID);
            return View(productoPhilips);
        }

        // POST: ProductoPhilips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productoPhilipsID,precio,codigoPhillips,descripcionPhillips,categoriaPhilipsID,productoID")] ProductoPhilips productoPhilips)
        {
            if (id != productoPhilips.productoPhilipsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoPhilips);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoPhilipsExists(productoPhilips.productoPhilipsID))
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
            ViewData["categoriaPhilipsID"] = new SelectList(_context.CategoriaPhilips, "categoriaPhilipsID", "categoriaPhilipsID", productoPhilips.categoriaPhilipsID);
            ViewData["productoID"] = new SelectList(_context.Set<Producto>(), "productoID", "productoID", productoPhilips.productoID);
            return View(productoPhilips);
        }

        // GET: ProductoPhilips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPhilips = await _context.ProductoPhilips
                .Include(p => p.CategoriaPhilips)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.productoPhilipsID == id);
            if (productoPhilips == null)
            {
                return NotFound();
            }

            return View(productoPhilips);
        }

        // POST: ProductoPhilips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoPhilips = await _context.ProductoPhilips.FindAsync(id);
            _context.ProductoPhilips.Remove(productoPhilips);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoPhilipsExists(int id)
        {
            return _context.ProductoPhilips.Any(e => e.productoPhilipsID == id);
        }
    }
}
