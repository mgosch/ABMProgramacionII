using WebApplication1.Data;
using WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Moq;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Tests
{
    public class GenresControllerTest
    {

        [Fact]
        public async Task IndexReturnsListGenres()
        {
            // Arrange
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

        [Fact]
        public async Task DetailsReturnUnicGenre()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IGenresRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestGenres().FirstOrDefault(
                            s => s.IdGenre == testSessionId));
            var controller = new GenresController(mockRepo.Object);

            // Act
            var result = await controller.Details(testSessionId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Genres>(
                viewResult.ViewData.Model);
            Assert.Equal("Arcade", model.Description);
            Assert.Equal(testSessionId, model.IdGenre);
        }

        [Fact]
        public async Task DeleteReturnUnicGenre()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IGenresRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestGenres().FirstOrDefault(
                            s => s.IdGenre == testSessionId));
            var controller = new GenresController(mockRepo.Object);

            // Act
            var result = await controller.Delete(testSessionId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Genres>(
                viewResult.ViewData.Model);
            Assert.Equal("Arcade", model.Description);
            Assert.Equal(testSessionId, model.IdGenre);
        }


        [Fact]
        public async Task EditReturnUnicGenre()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IGenresRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestGenres().FirstOrDefault(
                            s => s.IdGenre == testSessionId));
            var controller = new GenresController(mockRepo.Object);

            // Act
            var result = await controller.Edit(testSessionId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Genres>(
                viewResult.ViewData.Model);
            Assert.Equal("Arcade", model.Description);
            Assert.Equal(testSessionId, model.IdGenre);
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
                IdGenre = 2,
                Description = "Acción"
            });
            return genres;
        }
    }
}
