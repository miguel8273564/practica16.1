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
    public class MembresiasController : Controller
    {
        private readonly MyDbContext _context;

        public MembresiasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Membresias
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Membresias.Include(m => m.Usuario);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Membresias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Membresias == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresias
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }

        // GET: Membresias/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Membresias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,FechaExpiracion,UsuarioId")] Membresia membresia)
        {
            _context.Add(membresia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Membresias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Membresias == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresias.FindAsync(id);
            if (membresia == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", membresia.UsuarioId);
            return View(membresia);
        }

        // POST: Membresias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,FechaExpiracion,UsuarioId")] Membresia membresia)
        {
            if (id != membresia.Id)
            {
                return NotFound();
            }

            _context.Update(membresia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Membresias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Membresias == null)
            {
                return NotFound();
            }

            var membresia = await _context.Membresias
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }

        // POST: Membresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Membresias == null)
            {
                return Problem("Entity set 'MyDbContext.Membresias'  is null.");
            }
            var membresia = await _context.Membresias.FindAsync(id);
            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembresiaExists(int id)
        {
            return (_context.Membresias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
