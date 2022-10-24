using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.CoolerViewModels;
using WebApplication1.Models;

namespace WebApplication1
{
    public class GamesController : Controller
    {
        private readonly WebApplication1Context _context;

        public GamesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new GamesIndexData();
            viewModel.Games = await _context.Games
                  .Include(i => i.GamesGenres)
                    .ThenInclude(i => i.Genres)
                  .AsNoTracking()
                  .OrderBy(i => i.IdGame)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["idGame"] = id.Value;
                Games games = viewModel.Games.Where(
                    i => i.IdGame == id.Value).Single();
                viewModel.Genres = games.GamesGenres.Select(s => s.Genres);
            }

            return View(viewModel);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .FirstOrDefaultAsync(m => m.IdGame == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            var game = new Games();
            game.GamesGenres = new List<GamesGenres>();
            PopulateAssignedGenresData(game);
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Amount,Percent_Rent,Reward_Cooler_Coins,Image")] Games game, string[] selectedGenres)
        {

            if (selectedGenres != null)
            {
                game.GamesGenres = new List<GamesGenres>();
                foreach (var genres in selectedGenres)
                {
                    var genreToAdd = new GamesGenres { idGame = game.IdGame, idGenre = int.Parse(genres) };
                    game.GamesGenres.Add(genreToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                game.State = "HAB";
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateAssignedGenresData(game);

            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(i => i.GamesGenres).ThenInclude(i => i.Genres)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdGame == id);

            if (game == null)
            {
                return NotFound();
            }

            PopulateAssignedGenresData(game);

            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGame,Name,Description,State,Amount,Percent_Rent,Reward_Cooler_Coins,Image")] Games games)
        {
            if (id != games.IdGame)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.IdGame))
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
            return View(games);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .FirstOrDefaultAsync(m => m.IdGame == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Games == null)
            {
                return Problem("Entity set 'WebApplication1Context.Games'  is null.");
            }
            var games = await _context.Games.FindAsync(id);
            if (games != null)
            {
                _context.Games.Remove(games);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamesExists(int id)
        {
          return _context.Games.Any(e => e.IdGame == id);
        }

        private void PopulateAssignedGenresData(Games game)
        {
            var allGenres = _context.Genres;
            var gameGenres = new HashSet<int>(game.GamesGenres.Select(c => c.idGenre));
            var viewModel = new List<AssignedGenreData>();
            foreach (var genre in allGenres)
            {
                viewModel.Add(new AssignedGenreData
                {
                    IdGenre = genre.IdGenre,
                    Title = genre.Description,
                    Assigned = gameGenres.Contains(genre.IdGenre)
                });
            }
            ViewData["Genres"] = viewModel;
        }
    }
}
