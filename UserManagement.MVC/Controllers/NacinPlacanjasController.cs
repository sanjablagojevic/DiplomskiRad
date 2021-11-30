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
    public class NacinPlacanjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NacinPlacanjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NacinPlacanjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.NacinPlacanja.ToListAsync());
        }

        // GET: NacinPlacanjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacinPlacanja = await _context.NacinPlacanja
                .FirstOrDefaultAsync(m => m.NacinPlacanjaId == id);
            if (nacinPlacanja == null)
            {
                return NotFound();
            }

            return View(nacinPlacanja);
        }

        // GET: NacinPlacanjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NacinPlacanjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NacinPlacanjaId,NazivNacinaPlacanja")] NacinPlacanja nacinPlacanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacinPlacanja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacinPlacanja);
        }

        // GET: NacinPlacanjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacinPlacanja = await _context.NacinPlacanja.FindAsync(id);
            if (nacinPlacanja == null)
            {
                return NotFound();
            }
            return View(nacinPlacanja);
        }

        // POST: NacinPlacanjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NacinPlacanjaId,NazivNacinaPlacanja")] NacinPlacanja nacinPlacanja)
        {
            if (id != nacinPlacanja.NacinPlacanjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nacinPlacanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacinPlacanjaExists(nacinPlacanja.NacinPlacanjaId))
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
            return View(nacinPlacanja);
        }

        // GET: NacinPlacanjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacinPlacanja = await _context.NacinPlacanja
                .FirstOrDefaultAsync(m => m.NacinPlacanjaId == id);
            if (nacinPlacanja == null)
            {
                return NotFound();
            }

            return View(nacinPlacanja);
        }

        // POST: NacinPlacanjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nacinPlacanja = await _context.NacinPlacanja.FindAsync(id);
            _context.NacinPlacanja.Remove(nacinPlacanja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacinPlacanjaExists(int id)
        {
            return _context.NacinPlacanja.Any(e => e.NacinPlacanjaId == id);
        }
    }
}
