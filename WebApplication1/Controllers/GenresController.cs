using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenresRepository _genresRepository;

        public GenresController(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _genresRepository.ToListAsync());
        }

        // GET: Genres/Details/5
        //Recibe por parametro id del tipo int.
        //Devuelve genero. Si el genero no existe devuelve mensaje.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genres = await _genresRepository.GetByIdAsync(id);

            if (genres == null)
            {
                return NotFound();
            }

            return View(genres);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Recibe por parametros IdGenre, Description y un objeto genres del tipo Genres.
        //Devuelve creacion de genero.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGenre,Description")] Genres genres)
        {
            ModelState.Remove("GamesGenres");
            if (ModelState.IsValid)
            {
                await _genresRepository.AddAsync(genres);
                return RedirectToAction(nameof(Index));
            }
            return View(genres);
        }

        // GET: Genres/Edit/5
        //Recibe por parametro id del tipo int.
        //Devuelve genero. Si el genero no existe devuelve mensaje.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var genres = await _genresRepository.GetByIdAsync(id);
            if (genres == null)
            {
                return NotFound();
            }
            return View(genres);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Recibe por parametros IdGenre, Description y un objeto genres del tipo Genres.
        //Devuelve update de genero.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGenre,Description")] Genres genres)
        {
            if (id != genres.IdGenre)
            {
                return NotFound();
            }

            ModelState.Remove("GamesGenres");
            if (ModelState.IsValid)
            {
                try
                {
                    await _genresRepository.UpdateAsync(genres);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenresExists(genres.IdGenre))
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
            return View(genres);
        }

        // GET: Genres/Delete/5
        //Recibe por parametro id del tipo int.
        //Devuelve genero. Si el genero no existe devuelve mensaje.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genres = await _genresRepository.GetByIdAsync(id);
            if (genres == null)
            {
                return NotFound();
            }

            return View(genres);
        }

        // POST: Genres/Delete/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Recibe por parametro id del tipo int.
        //Devuelve delete de genero. Si el genero no existe devuelve mensaje.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genres = await _genresRepository.GetByIdAsync(id);
            if (genres != null)
            {
                _genresRepository.Delete(genres);
            }

            await _genresRepository.Async();
            return RedirectToAction(nameof(Index));
        }

        //Recibe por parametro id del tipo int.
        private bool GenresExists(int id)
        {
            return _genresRepository.GenreExist(id);
        }
    }
}
