using WebApplication1.Controllers;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Tests
{
    public class HomeControllerTest
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeController _controller;

        public HomeControllerTest()
        {
            _controller = new HomeController(_logger);
        }

        [Fact]
        public void Index()
        {
            var result = _controller.Index();
            Assert.NotNull(result);
        }
    }
}
