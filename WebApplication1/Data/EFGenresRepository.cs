using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class EFGenresRepository : IGenresRepository
    {
        private readonly WebApplication1Context _context;
        public EFGenresRepository(WebApplication1Context context)
        {
            _context = context;
        }

        public Task AddAsync(Genres genres)
        {
            _context.Add(genres);
            return _context.SaveChangesAsync();
        }

        public Task<List<Genres>> ToListAsync()
        {
            return _context.Genres.ToListAsync();
        }

        public Task UpdateAsync(Genres genres)
        {
            _context.Update(genres);
            return _context.SaveChangesAsync();
        }

        public Task<Genres> GetByIdAsync(int? id)
        {
            return _context.Genres
                    .FirstOrDefaultAsync(s => s.IdGenre == id);
        }

        public void Delete(Genres genres)
        {
            if (genres != null)
            {
                _context.Genres.Remove(genres);
            }
        }

        public Task Async()
        {
            return _context.SaveChangesAsync();
        }

        public bool GenreExist(int id)
        {
            return _context.Genres.Any(e => e.IdGenre == id);
        }
    }
}
