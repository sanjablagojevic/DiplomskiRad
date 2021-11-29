using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    public class UslugasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UslugasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Uslugas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Usluga.Include(u => u.Kategorija);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Uslugas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.Usluga
                .Include(u => u.Kategorija)
                .FirstOrDefaultAsync(m => m.UslugaId == id);
            if (usluga == null)
            {
                return NotFound();
            }

            return View(usluga);
        }

        // GET: Uslugas/Create
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_context.Kategorija, "KategorijaId", "KategorijaId");
            return View();
        }

        // POST: Uslugas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UslugaId,KategorijaId,NazivUsluge,CijenaUsluge")] Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usluga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorija, "KategorijaId", "KategorijaId", usluga.KategorijaId);
            return View(usluga);
        }

        // GET: Uslugas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.Usluga.FindAsync(id);
            if (usluga == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorija, "KategorijaId", "KategorijaId", usluga.KategorijaId);
            return View(usluga);
        }

        // POST: Uslugas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UslugaId,KategorijaId,NazivUsluge,CijenaUsluge")] Usluga usluga)
        {
            if (id != usluga.UslugaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usluga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugaExists(usluga.UslugaId))
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
            ViewData["KategorijaId"] = new SelectList(_context.Kategorija, "KategorijaId", "KategorijaId", usluga.KategorijaId);
            return View(usluga);
        }

        // GET: Uslugas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.Usluga
                .Include(u => u.Kategorija)
                .FirstOrDefaultAsync(m => m.UslugaId == id);
            if (usluga == null)
            {
                return NotFound();
            }

            return View(usluga);
        }

        // POST: Uslugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usluga = await _context.Usluga.FindAsync(id);
            _context.Usluga.Remove(usluga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugaExists(int id)
        {
            return _context.Usluga.Any(e => e.UslugaId == id);
        }
    }
}
