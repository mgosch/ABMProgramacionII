using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IGenresRepository
    {
        Task<List<Genres>> ToListAsync();

        Task UpdateAsync(Genres genres);

        Task AddAsync(Genres genres);

        Task DeleteAsync(Genres genres);

        Task<Genres> GetByIdAsync(int? id);

        DbSet<Genres> GetGenres();

        Task Async();

    }
}
