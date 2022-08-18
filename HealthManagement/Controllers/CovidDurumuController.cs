using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthManagement.Data;
using HealthManagement.Models;

namespace HealthManagement.Controllers
{
    public class CovidDurumuController : Controller
    {
        private readonly DenemeDBContext _context;

        public CovidDurumuController(DenemeDBContext context)
        {
            _context = context;
        }

        // GET: CovidDurumu
        public async Task<IActionResult> Index()
        {
            var denemeDBContext = _context.CovidDurumus.Include(c => c.Asi).Include(c => c.Belirti).Include(c => c.Eleman);
            return View(await denemeDBContext.ToListAsync());
        }

        // GET: CovidDurumu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidDurumu = await _context.CovidDurumus
                .Include(c => c.Asi)
                .Include(c => c.Belirti)
                .Include(c => c.Eleman)
                .FirstOrDefaultAsync(m => m.CovidDurumuId == id);
            if (covidDurumu == null)
            {
                return NotFound();
            }

            return View(covidDurumu);
        }

        // GET: CovidDurumu/Create
        public IActionResult Create()
        {
            ViewData["AsiId"] = new SelectList(_context.Asis, "AsiId", "AsiIsim");
            ViewData["BelirtiId"] = new SelectList(_context.Belirtis, "BelirtiId", "BelirtiIsim");
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim");
            return View();
        }

        // POST: CovidDurumu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CovidDurumuId,CovidBaslangic,CovidBitis,Covid,KronikHastalık,BelirtiId,AsiId,ElemanId")] CovidDurumu covidDurumu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covidDurumu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsiId"] = new SelectList(_context.Asis, "AsiId", "AsiIsim", covidDurumu.AsiId);
            ViewData["BelirtiId"] = new SelectList(_context.Belirtis, "BelirtiId", "BelirtiIsim", covidDurumu.BelirtiId);
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim", covidDurumu.ElemanId);
            return View(covidDurumu);
        }

        // GET: CovidDurumu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidDurumu = await _context.CovidDurumus.FirstOrDefaultAsync(m => m.CovidDurumuId == id);
            if (covidDurumu == null)
            {
                return NotFound();
            }
            ViewData["AsiId"] = new SelectList(_context.Asis, "AsiId", "AsiIsim", covidDurumu.AsiId);
            ViewData["BelirtiId"] = new SelectList(_context.Belirtis, "BelirtiId", "BelirtiIsim", covidDurumu.BelirtiId);
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim", covidDurumu.ElemanId);
            return View(covidDurumu);
        }

        // POST: CovidDurumu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CovidDurumuId,CovidBaslangic,CovidBitis,Covid,KronikHastalık,BelirtiId,AsiId,ElemanId")] CovidDurumu covidDurumu)
        {
            if (id != covidDurumu.CovidDurumuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covidDurumu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CovidDurumuExists(covidDurumu.CovidDurumuId))
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
            ViewData["AsiId"] = new SelectList(_context.Asis, "AsiId", "AsiIsim", covidDurumu.AsiId);
            ViewData["BelirtiId"] = new SelectList(_context.Belirtis, "BelirtiId", "BelirtiIsim", covidDurumu.BelirtiId);
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim", covidDurumu.ElemanId);
            return View(covidDurumu);
        }

        // GET: CovidDurumu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidDurumu = await _context.CovidDurumus
                .Include(c => c.Asi)
                .Include(c => c.Belirti)
                .Include(c => c.Eleman)
                .FirstOrDefaultAsync(m => m.CovidDurumuId == id);
            if (covidDurumu == null)
            {
                return NotFound();
            }

            return View(covidDurumu);
        }

        // POST: CovidDurumu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var covidDurumu = await _context.CovidDurumus.FirstOrDefaultAsync(m => m.CovidDurumuId == id);
            _context.CovidDurumus.Remove(covidDurumu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CovidDurumuExists(int id)
        {
            return _context.CovidDurumus.Any(e => e.CovidDurumuId == id);
        }
    }
}
