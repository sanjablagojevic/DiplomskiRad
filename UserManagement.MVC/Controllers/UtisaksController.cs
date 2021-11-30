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
    public class UtisaksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UtisaksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        // GET: Utisaks
        public async Task<IActionResult> Index()
        {
            var podatak = _context.Utisak.Include(u => u.User);
            return View(await podatak.ToListAsync());
        }

        // GET: Utisaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utisak = await _context.Utisak
                .FirstOrDefaultAsync(m => m.UtisakId == id);
            if (utisak == null)
            {
                return NotFound();
            }

            return View(utisak);
        }

        // GET: Utisaks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utisaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UtisakId,UserId,Ocjena,Komentar,Kreirano")] Utisak utisak)
        {
            var user = await GetCurrentUser();
            string userEmail = user.Email; // Here you gets user email 
            string userId = user.Id;
            utisak.UserId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(utisak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utisak);
        }

        // GET: Utisaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utisak = await _context.Utisak.FindAsync(id);
            if (utisak == null)
            {
                return NotFound();
            }
            return View(utisak);
        }

        // POST: Utisaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UtisakId,UserId,Ocjena,Komentar,Kreirano")] Utisak utisak)
        {
            if (id != utisak.UtisakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utisak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtisakExists(utisak.UtisakId))
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
            return View(utisak);
        }

        // GET: Utisaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utisak = await _context.Utisak
                .FirstOrDefaultAsync(m => m.UtisakId == id);
            if (utisak == null)
            {
                return NotFound();
            }

            return View(utisak);
        }

        // POST: Utisaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utisak = await _context.Utisak.FindAsync(id);
            _context.Utisak.Remove(utisak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtisakExists(int id)
        {
            return _context.Utisak.Any(e => e.UtisakId == id);
        }

        public FileResult GetFileFromBytes(byte[] bytesIn)
        {
            return File(bytesIn, "image/png");
        }


        [HttpGet]
        public async Task<IActionResult> GetUserImageFile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return File(user.ProfilePicture,"image/jpeg");
            }

            //FileResult imageUserFile = GetFileFromBytes(user.ProfilePicture);
            //return imageUserFile;
        }
    }
}
