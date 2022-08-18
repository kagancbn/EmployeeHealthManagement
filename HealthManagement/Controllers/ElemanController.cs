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
    public class ElemanController : Controller
    {
        private readonly DenemeDBContext _context;

        public ElemanController(DenemeDBContext context)
        {
            _context = context;
        }

        // GET: Eleman
        public async Task<IActionResult> Index()
        {
            var denemeDBContext = _context.Elemen.Include(e => e.Egitim).Include(e => e.KanGrubu).Include(e => e.Sehir);
            return View(await denemeDBContext.ToListAsync());
        }

        // GET: Eleman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleman = await _context.Elemen
                .Include(e => e.Egitim)
                .Include(e => e.KanGrubu)
                .Include(e => e.Sehir)
                .FirstOrDefaultAsync(m => m.ElemanId == id);
            if (eleman == null)
            {
                return NotFound();
            }

            return View(eleman);
        }

        // GET: Eleman/Create
        public IActionResult Create()
        {
            ViewData["EgitimId"] = new SelectList(_context.Egitims, "EgitimId", "EgitimDuzeyi");
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubus, "KanGrubuId", "KanGrubu1");
            ViewData["SehirId"] = new SelectList(_context.Sehirs, "SehirId", "Sehirİsim");
            return View();
        }

        // POST: Eleman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ElemanId,Isim,Soyisim,Maas,TcNo,Pozisyon,Hobiler,EgitimId,KanGrubuId,SehirId")] Eleman eleman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eleman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EgitimId"] = new SelectList(_context.Egitims, "EgitimId", "EgitimDuzeyi", eleman.EgitimId);
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubus, "KanGrubuId", "KanGrubu1", eleman.KanGrubuId);
            ViewData["SehirId"] = new SelectList(_context.Sehirs, "SehirId", "Sehirİsim", eleman.SehirId);
            return View(eleman);
        }

        // GET: Eleman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleman = await _context.Elemen.FindAsync(id);
            if (eleman == null)
            {
                return NotFound();
            }
            ViewData["EgitimId"] = new SelectList(_context.Egitims, "EgitimId", "EgitimDuzeyi", eleman.EgitimId);
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubus, "KanGrubuId", "KanGrubu1", eleman.KanGrubuId);
            ViewData["SehirId"] = new SelectList(_context.Sehirs, "SehirId", "Sehirİsim", eleman.SehirId);
            return View(eleman);
        }

        // POST: Eleman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ElemanId,Isim,Soyisim,Maas,TcNo,Pozisyon,Hobiler,EgitimId,KanGrubuId,SehirId")] Eleman eleman)
        {
            if (id != eleman.ElemanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eleman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElemanExists(eleman.ElemanId))
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
            ViewData["EgitimId"] = new SelectList(_context.Egitims, "EgitimId", "EgitimDuzeyi", eleman.EgitimId);
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubus, "KanGrubuId", "KanGrubu1", eleman.KanGrubuId);
            ViewData["SehirId"] = new SelectList(_context.Sehirs, "SehirId", "Sehirİsim", eleman.SehirId);
            return View(eleman);
        }

        // GET: Eleman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleman = await _context.Elemen
                .Include(e => e.Egitim)
                .Include(e => e.KanGrubu)
                .Include(e => e.Sehir)
                .FirstOrDefaultAsync(m => m.ElemanId == id);
            if (eleman == null)
            {
                return NotFound();
            }

            return View(eleman);
        }

        // POST: Eleman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eleman = await _context.Elemen.FindAsync(id);
            _context.Elemen.Remove(eleman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElemanExists(int id)
        {
            return _context.Elemen.Any(e => e.ElemanId == id);
        }
    }
}
