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
    public class CategoriaPhilipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaPhilipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaPhilips
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaPhilips.ToListAsync());
        }

        // GET: CategoriaPhilips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaPhilips = await _context.CategoriaPhilips
                .FirstOrDefaultAsync(m => m.categoriaPhilipsID == id);
            if (categoriaPhilips == null)
            {
                return NotFound();
            }

            return View(categoriaPhilips);
        }

        // GET: CategoriaPhilips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaPhilips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("categoriaPhilipsID,nombreCategoria")] CategoriaPhilips categoriaPhilips)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaPhilips);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaPhilips);
        }

        // GET: CategoriaPhilips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaPhilips = await _context.CategoriaPhilips.FindAsync(id);
            if (categoriaPhilips == null)
            {
                return NotFound();
            }
            return View(categoriaPhilips);
        }

        // POST: CategoriaPhilips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("categoriaPhilipsID,nombreCategoria")] CategoriaPhilips categoriaPhilips)
        {
            if (id != categoriaPhilips.categoriaPhilipsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaPhilips);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaPhilipsExists(categoriaPhilips.categoriaPhilipsID))
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
            return View(categoriaPhilips);
        }

        // GET: CategoriaPhilips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaPhilips = await _context.CategoriaPhilips
                .FirstOrDefaultAsync(m => m.categoriaPhilipsID == id);
            if (categoriaPhilips == null)
            {
                return NotFound();
            }

            return View(categoriaPhilips);
        }

        // POST: CategoriaPhilips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaPhilips = await _context.CategoriaPhilips.FindAsync(id);
            _context.CategoriaPhilips.Remove(categoriaPhilips);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaPhilipsExists(int id)
        {
            return _context.CategoriaPhilips.Any(e => e.categoriaPhilipsID == id);
        }
    }
}
