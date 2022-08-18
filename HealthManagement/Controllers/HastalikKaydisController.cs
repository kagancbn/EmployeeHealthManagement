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
    public class HastalikKaydisController : Controller
    {
        private readonly DenemeDBContext _context;

        public HastalikKaydisController(DenemeDBContext context)
        {
            _context = context;
        }

        // GET: HastalikKaydis
        public async Task<IActionResult> Index()
        {
            var denemeDBContext = _context.HastalikKaydis.Include(h => h.Eleman).Include(h => h.Hastalik).Include(h => h.Ilac).Include(h => h.Semptom);
            return View(await denemeDBContext.ToListAsync());
        }

        // GET: HastalikKaydis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastalikKaydi = await _context.HastalikKaydis
                .Include(h => h.Eleman)
                .Include(h => h.Hastalik)
                .Include(h => h.Ilac)
                .Include(h => h.Semptom)
                .FirstOrDefaultAsync(m => m.HastalikKaydiId == id);
            if (hastalikKaydi == null)
            {
                return NotFound();
            }

            return View(hastalikKaydi);
        }

        // GET: HastalikKaydis/Create
        public IActionResult Create()
        {
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim");
            ViewData["HastalikId"] = new SelectList(_context.Hastaliklars, "HastalikId", "HastalikIsim");
            ViewData["IlacId"] = new SelectList(_context.Recetes, "IlacId", "IlacIsim");
            ViewData["SemptomId"] = new SelectList(_context.Semptoms, "SemptomId", "SemptomIsim");
            return View();
        }

        // POST: HastalikKaydis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HastalikKaydiId,SemptomId,HastalikId,IlacId,HastalikTarih,ElemanId")] HastalikKaydi hastalikKaydi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastalikKaydi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim", hastalikKaydi.ElemanId);
            ViewData["HastalikId"] = new SelectList(_context.Hastaliklars, "HastalikId", "HastalikIsim", hastalikKaydi.HastalikId);
            ViewData["IlacId"] = new SelectList(_context.Recetes, "IlacIsim", "IlacDoz", hastalikKaydi.IlacId);
            ViewData["SemptomId"] = new SelectList(_context.Semptoms, "SemptomId", "SemptomIsim", hastalikKaydi.SemptomId);
            return View(hastalikKaydi);
        }

        // GET: HastalikKaydis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastalikKaydi = await _context.HastalikKaydis.FirstOrDefaultAsync(m => m.HastalikKaydiId == id); 
            if (hastalikKaydi == null)
            {
                return NotFound();
            }
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim", hastalikKaydi.ElemanId);
            ViewData["HastalikId"] = new SelectList(_context.Hastaliklars, "HastalikId", "HastalikIsim", hastalikKaydi.HastalikId);
            ViewData["IlacId"] = new SelectList(_context.Recetes, "IlacId", "IlacIsim", hastalikKaydi.IlacId);
            ViewData["SemptomId"] = new SelectList(_context.Semptoms, "SemptomId", "SemptomIsim", hastalikKaydi.SemptomId);
            return View(hastalikKaydi);
        }

        // POST: HastalikKaydis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HastalikKaydiId,SemptomId,HastalikId,IlacId,HastalikTarih,ElemanId")] HastalikKaydi hastalikKaydi)
        {
            if (id != hastalikKaydi.HastalikKaydiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastalikKaydi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastalikKaydiExists(hastalikKaydi.HastalikKaydiId))
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
            ViewData["ElemanId"] = new SelectList(_context.Elemen, "ElemanId", "Isim", hastalikKaydi.ElemanId);
            ViewData["HastalikId"] = new SelectList(_context.Hastaliklars, "HastalikId", "HastalikIsim", hastalikKaydi.HastalikId);
            ViewData["IlacId"] = new SelectList(_context.Recetes, "IlacId", "IlacDoz", hastalikKaydi.IlacId);
            ViewData["SemptomId"] = new SelectList(_context.Semptoms, "SemptomId", "SemptomIsim", hastalikKaydi.SemptomId);
            return View(hastalikKaydi);
        }

        // GET: HastalikKaydis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastalikKaydi = await _context.HastalikKaydis
                .Include(h => h.Eleman)
                .Include(h => h.Hastalik)
                .Include(h => h.Ilac)
                .Include(h => h.Semptom)
                .FirstOrDefaultAsync(m => m.HastalikKaydiId == id);
            if (hastalikKaydi == null)
            {
                return NotFound();
            }

            return View(hastalikKaydi);
        }

        // POST: HastalikKaydis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hastalikKaydi = await _context.HastalikKaydis.FirstOrDefaultAsync(m => m.HastalikKaydiId == id);
            _context.HastalikKaydis.Remove(hastalikKaydi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastalikKaydiExists(int id)
        {
            return _context.HastalikKaydis.Any(e => e.HastalikKaydiId == id);
        }
    }
}
