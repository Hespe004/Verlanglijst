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
    public class VerzamelController : Controller
    {
        private readonly MijnContext _context;

        public VerzamelController(MijnContext context)
        {
            _context = context;
        }

        // GET: Verzamel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Verzamel_Lijsts.ToListAsync());
        }

        // GET: Verzamel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verzamel_Lijst = await _context.Verzamel_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verzamel_Lijst == null)
            {
                return NotFound();
            }

            return View(verzamel_Lijst);
        }

        // GET: Verzamel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verzamel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Type, string Titel, string Price, int Waarde, string Link)
        {
            Verzamel_Lijst verzamel_Lijst = new Verzamel_Lijst(Type, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);

            if (ModelState.IsValid)
            {
                _context.Add(verzamel_Lijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verzamel_Lijst);
        }

        // GET: Verzamel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verzamel_Lijst = await _context.Verzamel_Lijsts.FindAsync(id);
            if (verzamel_Lijst == null)
            {
                return NotFound();
            }
            return View(verzamel_Lijst);
        }

        // POST: Verzamel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Type, string Titel, string Price, int Waarde, string Link)
        {
            Verzamel_Lijst verzamel_Lijst = new Verzamel_Lijst(Type, Titel, decimal.Parse(Price.Replace(".", ",")), Waarde, Link);
            verzamel_Lijst.Id = id;
            // if (id != verzamel_Lijst.Id)
            // {
            //     return NotFound();
            // }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verzamel_Lijst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Verzamel_LijstExists(verzamel_Lijst.Id))
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
            return View(verzamel_Lijst);
        }

        // GET: Verzamel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verzamel_Lijst = await _context.Verzamel_Lijsts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verzamel_Lijst == null)
            {
                return NotFound();
            }

            return View(verzamel_Lijst);
        }

        // POST: Verzamel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verzamel_Lijst = await _context.Verzamel_Lijsts.FindAsync(id);
            _context.Verzamel_Lijsts.Remove(verzamel_Lijst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Verzamel_LijstExists(int id)
        {
            return _context.Verzamel_Lijsts.Any(e => e.Id == id);
        }
    }
}
