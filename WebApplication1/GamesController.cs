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
        // Recibe por parametro id del tipo int.
        // Devuelve el juego y sus generos.
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
        //Recibe por parametro id del tipo int.
        //Devuelve el juego y sus comentarios en caso de tenerlos. Si el juego no existe devuelve mensaje.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                        .Include(i => i.Comments)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.IdGame == id);

            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games/CreateGame
        //Devuelve lista de generos.
        public IActionResult CreateGame()
        {
            var game = new Games();
            game.GamesGenres = new List<GamesGenres>();
            PopulateAssignedGenresData(game);
            return View();
        }

        // POST: Games/CreateGame
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Recibe por parametros Name, Description, Amount, Percent_Rent, Reward_Cooler_Coins, Image, un objeto game del tipo Game y una cadena string
        //Devuelve por cada genero que tenga el juego crea un registro en la tabla GamesGenres y retorna la vista del juego.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGame([Bind("Name,Description,Amount,Percent_Rent,Reward_Cooler_Coins,Image")] Games game, string[] selectedGenres)
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

            ModelState.Remove("Comments");
            ModelState.Remove("GamesGenres");
            ModelState.Remove("State");
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
        //Recibe por parametro id del tipo int.
        //Devuelve juego. Si el juego no existe devuelve mensaje.
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
        //Recibe por parametros Name, Description, Amount, Percent_Rent, Reward_Cooler_Coins, Image y un objeto game del tipo Game.
        //Devuelve un update de la info del juego. Si el juego no existe devuelve mensaje.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGame,Name,Description,State,Amount,Percent_Rent,Reward_Cooler_Coins,Image")] Games games, string[] selectedGenres)
        {
            if (id != games.IdGame)
            {
                return NotFound();
            }

            var gameToUpdate = await _context.Games
                        .Include(i => i.GamesGenres)
                        .ThenInclude(i => i.Genres)
                .FirstOrDefaultAsync(m => m.IdGame == id);

            ModelState.Remove("Comments");
            ModelState.Remove("GamesGenres");
            ModelState.Remove("State");
            if (ModelState.IsValid)
            {
                gameToUpdate.Name = games.Name;
                gameToUpdate.Description = games.Description;
                gameToUpdate.Amount = games.Amount;
                gameToUpdate.Percent_Rent = games.Percent_Rent;
                gameToUpdate.Reward_Cooler_Coins = games.Reward_Cooler_Coins;
                gameToUpdate.Image = games.Image;
                gameToUpdate.State = "HAB";
                _context.Update(gameToUpdate);
                UpdateGamesGenres(selectedGenres, gameToUpdate);
                
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }

                return RedirectToAction(nameof(Index));
            }

            UpdateGamesGenres(selectedGenres, gameToUpdate);
            PopulateAssignedGenresData(gameToUpdate);

            return View(gameToUpdate);
        }

        // GET: Games/Delete/5
        //Recibe por parametro id del tipo int.
        //Devuelve juego. Si el juego no existe devuelve mensaje.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Recibe por parametro id del tipo int.
        //Devuelve borrado del juego. Si el juego no existe devuelve mensaje.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Games game = await _context.Games
                            .Include(i => i.GamesGenres)
                            .SingleAsync(i => i.IdGame == id);

            _context.Games.Remove(game);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Games/CreateComment/5
        //Recibe por parametro id del tipo int.
        //Devuelve juego. Si el juego no existe devuelve mensaje.
        
        public async Task<IActionResult> CreateComment(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            ViewData["idGame"] = id.Value;

            return View();
        }

        // POST: Games/CreateComment
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Recibe por parametros IdGame, Comment y un objeto comments del tipo Comments.
        //Devuelve Agrega comentario al juego.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment([Bind("IdGame,Comment")] Comments comments)
        {
            ModelState.Remove("Games");
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comments);
        }

        private bool GamesExists(int id)
        {
          return _context.Games.Any(e => e.IdGame == id);
        }

        //Recibe por parametro un objeto del tipo Game
        //Devuelve asigna un genero o listado de generos al juego.
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


        //Recibe por parametro un objeto del tipo Games y una lista de genres
        //Realiza el update de un genero o listado de generos al juego
        private void UpdateGamesGenres(string[] selectedGenres, Games gameToUpdate)
        {
            if (selectedGenres == null)
            {
                gameToUpdate.GamesGenres = new List<GamesGenres>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var gamesGenres = new HashSet<int>
                (gameToUpdate.GamesGenres.Select(c => c.Genres.IdGenre));
            foreach (var genre in _context.Genres)
            {
                if (selectedGenresHS.Contains(genre.IdGenre.ToString()))
                {
                    if (!gamesGenres.Contains(genre.IdGenre))
                    {
                        gameToUpdate.GamesGenres.Add(new GamesGenres { idGame = gameToUpdate.IdGame, idGenre = genre.IdGenre });
                    }
                }
                else
                {

                    if (gamesGenres.Contains(genre.IdGenre))
                    {
                        GamesGenres genreToRemove = gameToUpdate.GamesGenres.FirstOrDefault(i => i.idGenre == genre.IdGenre);
                        _context.Remove(genreToRemove);
                    }
                }
            }
        }
    }
}
