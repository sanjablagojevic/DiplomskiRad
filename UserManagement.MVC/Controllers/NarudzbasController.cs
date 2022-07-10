using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
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
        public INotyfService _notifyService { get; }

        public NarudzbasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, INotyfService notifyService)
        {
            _context = context;
            _userManager = userManager;
            _notifyService = notifyService;
        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        // GET: Narudzbas
        public async Task<IActionResult> Index(int p=1)
        {
            int pageSize = 7;
            var applicationDbContext = _context.Narudzba.Include(n => n.User).Include(n => n.Usluga).Where(n => n.NarudzbaPotvrdjena != true).Skip((p - 1) * pageSize).Take(pageSize).OrderBy(n=>n.DatumNarudzbe);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Narudzba.Count() / pageSize);

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

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NarudzbaId,UslugaId,UserId,AdresaNarudzbe,DatumNarudzbe,VrijemePocetka,VrijemeKraja,NarudzbaPotvrdjena,EmailNarucioca,BrojTelefonaNarucioca,BrojKvadrata")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narudzba);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home", new { area = "" });
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

        public async Task<ActionResult> PotvrdiNarudzbu(int id)
        {
            var user = await GetCurrentUser();
            string userId = user.Id;
            var narudzba = await _context.Narudzba.FindAsync(id);
            narudzba.UserId = userId;
            narudzba.NarudzbaPotvrdjena = true;
            _context.Update(narudzba);
            await _context.SaveChangesAsync();

            return RedirectToAction("PotvrdjeneNarudzbe","Narudzbas");
        }


            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NarudzbaId,UslugaId,UserId,AdresaNarudzbe,DatumNarudzbe,VrijemePocetka,VrijemeKraja,NarudzbaPotvrdjena,EmailNarucioca,BrojTelefonaNarucioca,BrojKvadrata")] Narudzba narudzba)
        {
            var user = await GetCurrentUser();
            string userEmail = user.Email; 
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
                return RedirectToAction("PotvrdjeneNarudzbe", "Narudzbas");
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
        public async Task<IActionResult> PotvrdjeneNarudzbe(int p = 1)
        {
            int pageSize = 7;
            var potvrdjenjeNarudzbe = _context.Narudzba.Include(n => n.User).Include(n => n.Usluga).Where(m => m.NarudzbaPotvrdjena==true).Skip((p - 1) * pageSize).Take(pageSize).OrderByDescending(d=>d.DatumNarudzbe);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Narudzba.Count() / pageSize);

            return View(await potvrdjenjeNarudzbe.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> MojeNarudzbe()
        {
            var userId = User.FindFirstValue(ClaimTypes.Email);

            var mojeNarudzbe = _context.Narudzba.Include(n => n.User).Include(n => n.Usluga).Where(m => m.NarudzbaPotvrdjena == true).Where(m => m.User.Email== "superadmin@gmail.com");
            return View(await mojeNarudzbe.ToListAsync());
        }
        public async Task<ActionResult> MejlPotvrde(int? id)
        {
            Narudzba narudzba = await _context.Narudzba.FindAsync(id);
            string subject = "HouseKeeping Service";
            string body = "Ovim mejlom potvrđujemo Vašu narudžbu na dan: " + narudzba.DatumNarudzbe.ToString("dd.MM.yyyy.") + " u vrijeme: " + narudzba.VrijemePocetka?.ToString("HH:mm")+ ". ";
            string to = narudzba.EmailNarucioca;
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("sanjab2801@gmail.com");
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("sanjab2801@gmail.com", "ViliMicika<3");
            //smtp.Send(mm);
            
            ViewBag.message = "This Mail Has Been Sent To " + to + " Successfully...!";
            _notifyService.Success("Confirmation E-mail Has Been Sent Sucessfully!", 5);
            return RedirectToAction("PotvrdjeneNarudzbe", "Narudzbas");
            
        }

        public async Task<ActionResult> Invoice(int? id)
        {
            Narudzba narudzba = await _context.Narudzba.FindAsync(id);
            return View(narudzba);
        }
    }
}
