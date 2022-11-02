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


        public DbSet<Genres> GetGenres()
        {
            return _context.Genres;
        }

        public Task<Genres> GetByIdAsync(int? id)
        {
            return _context.Genres
                    .FirstOrDefaultAsync(s => s.IdGenre == id);
        }

        public Task DeleteAsync(Genres genres)
        {
            _context.Genres.Remove(genres);
            return _context.SaveChangesAsync();
        }

        public Task Async()
        {
            return _context.SaveChangesAsync();
        }
    }
}
