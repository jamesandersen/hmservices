namespace Services.Tests.Controllers
{
    using HMServices.Controllers;
    using HMServices.Models;
    using HMServices.Services;
    using Xunit;
    using Moq;
    using System.Threading.Tasks;

    public class ValuesTests
    {
        private Mock<ISECService> _mockSECService;
        private readonly ValuesController _valueController;

        public ValuesTests() {
            _mockSECService = new Mock<ISECService>();
            _valueController = new ValuesController(_mockSECService.Object);
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