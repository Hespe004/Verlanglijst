using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using src.Models;

namespace Site.Controllers
{
    public class PSController : Controller
    {
        private readonly MijnContext _context;

        public PSController(MijnContext context)
        {
            _context = context;
        }

        // GET: PS
        public async Task<IActionResult> Index()
        {
            return View(await _context.PS_Lijsts.ToListAsync());
        }

        // GET: PS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pS_Lijst = await _context.PS_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pS_Lijst == null)
            {
                return NotFound();
            }

            return View(pS_Lijst);
        }

        // GET: PS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Gen, string Titel, string Price, int Waarde, string Link)
        {
            PS_Lijst pS_Lijst = new PS_Lijst(Gen, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);

            if (ModelState.IsValid)
            {
                _context.Add(pS_Lijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pS_Lijst);
        }

        // GET: PS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pS_Lijst = await _context.PS_Lijsts.FindAsync(id);
            if (pS_Lijst == null)
            {
                return NotFound();
            }
            return View(pS_Lijst);
        }

        // POST: PS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Gen, string Titel, string Price, int Waarde, string Link)
        {
            PS_Lijst pS_Lijst = new PS_Lijst(Gen, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);
            pS_Lijst.Id = id;
            
            // if (id != pS_Lijst.Id)
            // {
            //     return NotFound();
            // }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pS_Lijst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PS_LijstExists(pS_Lijst.Id))
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
            return View(pS_Lijst);
        }

        // GET: PS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pS_Lijst = await _context.PS_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pS_Lijst == null)
            {
                return NotFound();
            }

            return View(pS_Lijst);
        }

        // POST: PS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pS_Lijst = await _context.PS_Lijsts.FindAsync(id);
            _context.PS_Lijsts.Remove(pS_Lijst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PS_LijstExists(int id)
        {
            return _context.PS_Lijsts.Any(e => e.Id == id);
        }
    }
}
