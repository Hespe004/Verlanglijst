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
    public class OverigController : Controller
    {
        private readonly MijnContext _context;

        public OverigController(MijnContext context)
        {
            _context = context;
        }

        // GET: Overig
        public async Task<IActionResult> Index()
        {
            return View(await _context.Overig_Lijsts.ToListAsync());
        }

        // GET: Overig/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overig_Lijst = await _context.Overig_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (overig_Lijst == null)
            {
                return NotFound();
            }

            return View(overig_Lijst);
        }

        // GET: Overig/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Overig/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Type, string Titel, string Price, int Waarde, string Link)
        {
            Overig_Lijst overig_Lijst = new Overig_Lijst(Type, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);

            if (ModelState.IsValid)
            {
                _context.Add(overig_Lijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(overig_Lijst);
        }

        // GET: Overig/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overig_Lijst = await _context.Overig_Lijsts.FindAsync(id);
            if (overig_Lijst == null)
            {
                return NotFound();
            }
            return View(overig_Lijst);
        }

        // POST: Overig/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Type, string Titel, string Price, int Waarde, string Link)
        {
            Overig_Lijst overig_Lijst = new Overig_Lijst(Type, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);
            overig_Lijst.Id = id;

            // if (id != overig_Lijst.Id)
            // {
            //     return NotFound();
            // }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(overig_Lijst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Overig_LijstExists(overig_Lijst.Id))
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
            return View(overig_Lijst);
        }

        // GET: Overig/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overig_Lijst = await _context.Overig_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (overig_Lijst == null)
            {
                return NotFound();
            }

            return View(overig_Lijst);
        }

        // POST: Overig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var overig_Lijst = await _context.Overig_Lijsts.FindAsync(id);
            _context.Overig_Lijsts.Remove(overig_Lijst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Overig_LijstExists(int id)
        {
            return _context.Overig_Lijsts.Any(e => e.Id == id);
        }
    }
}
