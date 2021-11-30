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
    public class BRController : Controller
    {
        private readonly MijnContext _context;

        public BRController(MijnContext context)
        {
            _context = context;
        }

        // GET: BR
        public async Task<IActionResult> Index()
        {
            return View(await _context.BR_Lijsts.ToListAsync());
        }

        // GET: BR/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bR_Lijst = await _context.BR_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bR_Lijst == null)
            {
                return NotFound();
            }

            return View(bR_Lijst);
        }

        // GET: BR/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Type, string Titel, string Price, int Waarde, string Link)
        {
            BR_Lijst bR_Lijst = new BR_Lijst(Type, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);

            if (ModelState.IsValid)
            {
                _context.Add(bR_Lijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bR_Lijst);
        }

        // GET: BR/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bR_Lijst = await _context.BR_Lijsts.FindAsync(id);
            if (bR_Lijst == null)
            {
                return NotFound();
            }
            return View(bR_Lijst);
        }

        // POST: BR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Type, string Titel, string Price, int Waarde, string Link)
        {
            BR_Lijst bR_Lijst = new BR_Lijst(Type, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);
            bR_Lijst.Id = id;
            
            // if (id != bR_Lijst.Id)
            // {
            //     return NotFound();
            // }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bR_Lijst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BR_LijstExists(bR_Lijst.Id))
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
            return View(bR_Lijst);
        }

        // GET: BR/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bR_Lijst = await _context.BR_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bR_Lijst == null)
            {
                return NotFound();
            }

            return View(bR_Lijst);
        }

        // POST: BR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bR_Lijst = await _context.BR_Lijsts.FindAsync(id);
            _context.BR_Lijsts.Remove(bR_Lijst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BR_LijstExists(int id)
        {
            return _context.BR_Lijsts.Any(e => e.Id == id);
        }
    }
}
