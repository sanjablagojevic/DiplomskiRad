using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    public class NarudzbasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public NarudzbasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        // GET: Narudzbas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Narudzba.Include(n => n.User).Include(n => n.Usluga).Where(n => n.NarudzbaPotvrdjena != true);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Narudzbas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narudzba = await _context.Narudzba
                .Include(n => n.User)
                .Include(n => n.Usluga)
                .FirstOrDefaultAsync(m => m.NarudzbaId == id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return View(narudzba);
        }

        // GET: Narudzbas/Create
        public IActionResult Create()
        {
            ViewData["UslugaId"] = new SelectList(_context.Usluga, nameof(Usluga.UslugaId), nameof(Usluga.NazivUsluge));
            return View();
        }

        // POST: Narudzbas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NarudzbaId,UslugaId,UserId,AdresaNarudzbe,DatumNarudzbe,VrijemePocetka,VrijemeKraja,NarudzbaPotvrdjena,EmailNarucioca,BrojTelefonaNarucioca")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narudzba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", narudzba.UserId);
            ViewData["UslugaId"] = new SelectList(_context.Usluga, "UslugaId", "UslugaId", narudzba.UslugaId);
            return View(narudzba);
        }

        // GET: Narudzbas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narudzba = await _context.Narudzba.FindAsync(id);
            if (narudzba == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", narudzba.UserId);
            ViewData["UslugaId"] = new SelectList(_context.Usluga, "UslugaId", "UslugaId", narudzba.UslugaId);
            return View(narudzba);
        }

        // POST: Narudzbas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NarudzbaId,UslugaId,UserId,AdresaNarudzbe,DatumNarudzbe,VrijemePocetka,VrijemeKraja,NarudzbaPotvrdjena,EmailNarucioca,BrojTelefonaNarucioca")] Narudzba narudzba)
        {
            var user = await GetCurrentUser();
            string userEmail = user.Email; // Here you gets user email 
            string userId = user.Id;
            narudzba.UserId = userId;
            narudzba.NarudzbaPotvrdjena = true;
            
            if (id != narudzba.NarudzbaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narudzba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarudzbaExists(narudzba.NarudzbaId))
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
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", narudzba.UserId);
            ViewData["UslugaId"] = new SelectList(_context.Usluga, "UslugaId", "UslugaId", narudzba.UslugaId);
            return View(narudzba);
        }

        // GET: Narudzbas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narudzba = await _context.Narudzba
                .Include(n => n.User)
                .Include(n => n.Usluga)
                .FirstOrDefaultAsync(m => m.NarudzbaId == id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return View(narudzba);
        }

        // POST: Narudzbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var narudzba = await _context.Narudzba.FindAsync(id);
            _context.Narudzba.Remove(narudzba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarudzbaExists(int id)
        {
            return _context.Narudzba.Any(e => e.NarudzbaId == id);
        }

        [HttpGet]
        public async Task<IActionResult> PotvrdjeneNarudzbe()
        {
            var potvrdjenjeNarudzbe = _context.Narudzba.Include(n => n.User).Include(n => n.Usluga).Where(m => m.NarudzbaPotvrdjena==true);
            return View(await potvrdjenjeNarudzbe.ToListAsync());
        }
    }
}
