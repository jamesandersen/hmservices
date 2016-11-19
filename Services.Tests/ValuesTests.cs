namespace Services.Tests.Controllers
{
    using HMServices.Controllers;
    using HMServices.Models;
    using HMServices.Services;
    using Xunit;
    using Moq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class ValuesTests
    {
        private Mock<ISECService> _mockSECService;
        private Mock<ILogger<ValuesController>> _mockLogger;
        private readonly ValuesController _valueController;

        public ValuesTests() {
            _mockSECService = new Mock<ISECService>();
            _mockLogger = new Mock<ILogger<ValuesController>>();
            _valueController = new ValuesController(_mockSECService.Object, _mockLogger.Object);
        }
        
        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _valueController.Get(3);

            Assert.Equal(result, $"value");
        }

        [Fact]
        public async Task ReturnSymbols()
        {
            _mockSECService.Setup(m => m.GetSymbols())
                .ReturnsAsync(new [] { new Symbol { Name = "foo" }, new Symbol { Name = "bar" } });
            var result = await _valueController.Get();

            Assert.NotNull(result);
        }
    }
}