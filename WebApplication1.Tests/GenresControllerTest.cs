using WebApplication1.Data;
using WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Moq;

namespace WebApplication1.Tests
{
    public class GenresControllerTest
    {

        [Fact]
        public async Task IndexReturnsListGenres()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IGenresRepository>();
            mockRepo.Setup(repo => repo.ToListAsync())
                .ReturnsAsync(GetTestGenres());
            var controller = new GenresController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Genres>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private List<Genres> GetTestGenres()
        {
            var genres = new List<Genres>();
            genres.Add(new Genres()
            {
                IdGenre = 1,
                Description = "Arcade"
            });
            genres.Add(new Genres()
            {
                IdGenre = 1,
                Description = "Acción"
            });
            return genres;
        }

    }
}
