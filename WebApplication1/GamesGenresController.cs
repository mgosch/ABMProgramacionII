using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public class GamesGenresController : Controller
    {
        private readonly WebApplication1Context _context;

        public GamesGenresController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: GamesGenres
        public async Task<IActionResult> Index()
        {
              return _context.GamesGenres != null ? 
                          View(await _context.GamesGenres.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.GamesGenres'  is null.");
        }

        // GET: GamesGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GamesGenres == null)
            {
                return NotFound();
            }

            var gamesGenres = await _context.GamesGenres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamesGenres == null)
            {
                return NotFound();
            }

            return View(gamesGenres);
        }

        // GET: GamesGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GamesGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GamesId,GenresId")] GamesGenres gamesGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamesGenres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamesGenres);
        }

        // GET: GamesGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GamesGenres == null)
            {
                return NotFound();
            }

            var gamesGenres = await _context.GamesGenres.FindAsync(id);
            if (gamesGenres == null)
            {
                return NotFound();
            }
            return View(gamesGenres);
        }

        // POST: GamesGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GamesId,GenresId")] GamesGenres gamesGenres)
        {
            if (id != gamesGenres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamesGenres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesGenresExists(gamesGenres.Id))
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
            return View(gamesGenres);
        }

        // GET: GamesGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GamesGenres == null)
            {
                return NotFound();
            }

            var gamesGenres = await _context.GamesGenres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamesGenres == null)
            {
                return NotFound();
            }

            return View(gamesGenres);
        }

        // POST: GamesGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GamesGenres == null)
            {
                return Problem("Entity set 'WebApplication1Context.GamesGenres'  is null.");
            }
            var gamesGenres = await _context.GamesGenres.FindAsync(id);
            if (gamesGenres != null)
            {
                _context.GamesGenres.Remove(gamesGenres);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamesGenresExists(int id)
        {
          return (_context.GamesGenres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
