using WebApplication1.Data;
using WebApplication1.Controllers;

namespace WebApplication1.Tests
{
    public class GenresControllerTest
    {
        private readonly WebApplication1Context _context;
        private readonly GenresController _controller;

        public GenresControllerTest()
        {
            _controller = new GenresController(_context);
        }

        [Fact]
        public void Index()
        {
            var result = _controller.Index();
            Assert.NotNull(result);
        }

        [Fact]
        public void Details()
        {
            var result = _controller.Details(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void Edit()
        {
            var result = _controller.Edit(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete()
        {
            var result = _controller.Delete(null);
            Assert.NotNull(result);
        }
    }
}
