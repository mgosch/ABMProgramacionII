using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IGenresRepository
    {
        Task<List<Genres>> ToListAsync();

        Task UpdateAsync(Genres genres);

        Task AddAsync(Genres genres);

        void Delete(Genres genres);

        Task<Genres> GetByIdAsync(int? id);

        Task Async();

        bool GenreExist(int id);

    }
}
