using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;

namespace EFconASPyMVC.Controllers
{
    public class LibroCategoriasController : Controller
    {
        private readonly MyDbContext _context;

        public LibroCategoriasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: LibroCategorias
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.LibroCategorias.Include(l => l.Categoria).Include(l => l.Libro);
            return View(await myDbContext.ToListAsync());
        }

        // GET: LibroCategorias/Details/5
        public async Task<IActionResult> Details(int? libroId, int? categoriaId)
        {
            if (libroId == null || categoriaId == null)
            {
                return NotFound();
            }

            var libroCategoria = await _context.LibroCategorias
                .Include(l => l.Categoria)
                .Include(l => l.Libro)
                .FirstOrDefaultAsync(m => m.LibroId == libroId && m.CategoriaId == categoriaId);
            if (libroCategoria == null)
            {
                return NotFound();
            }

            return View(libroCategoria);
        }

        // GET: LibroCategorias/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id");
            ViewData["LibroId"] = new SelectList(_context.Libros, "Id", "Id");
            return View();
        }

        // POST: LibroCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibroId,CategoriaId")] LibroCategoria libroCategoria)
        {

            _context.Add(libroCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: LibroCategorias/Edit/5
        public async Task<IActionResult> Edit(int? libroId, int? categoriaId)
        {
            if (libroId == null || categoriaId == null)
            {
                return NotFound();
            }

            var libroCategoria = await _context.LibroCategorias.FindAsync(libroId, categoriaId);
            if (libroCategoria == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", libroCategoria.CategoriaId);
            ViewData["LibroId"] = new SelectList(_context.Libros, "Id", "Id", libroCategoria.LibroId);
            return View(libroCategoria);
        }

        // POST: LibroCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int libroId, int categoriaId, [Bind("LibroId,CategoriaId")] LibroCategoria libroCategoria)
        {
            if (libroId != libroCategoria.LibroId || categoriaId != libroCategoria.CategoriaId)
            {
                return NotFound();
            }

            _context.Update(libroCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: LibroCategorias/Delete/5
        public async Task<IActionResult> Delete(int? libroId, int? categoriaId)
        {
            if (libroId == null || categoriaId == null)
            {
                return NotFound();
            }

            var libroCategoria = await _context.LibroCategorias
                .Include(l => l.Categoria)
                .Include(l => l.Libro)
                .FirstOrDefaultAsync(m => m.LibroId == libroId && m.CategoriaId == categoriaId);
            if (libroCategoria == null)
            {
                return NotFound();
            }

            return View(libroCategoria);
        }

        // POST: LibroCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int libroId, int categoriaId)
        {
            if (_context.LibroCategorias == null)
            {
                return Problem("Entity set 'MyDbContext.LibroCategorias'  is null.");
            }
            var libroCategoria = await _context.LibroCategorias.FindAsync(libroId, categoriaId);
            if (libroCategoria != null)
            {
                _context.LibroCategorias.Remove(libroCategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroCategoriaExists(int libroId, int categoriaId)
        {
            return (_context.LibroCategorias?.Any(e => e.LibroId == libroId && e.CategoriaId == categoriaId)).GetValueOrDefault();
        }
    }
}
