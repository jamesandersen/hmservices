namespace Services.Tests.Controllers
{
    using HMServices.Controllers;
    using HMServices.Models;
    using Xunit;
    using Moq;
    using Microsoft.Extensions.Options;

    public class ValuesTests
    {
        private readonly ValuesController _valueController;

        public ValuesTests() {
            _valueController = new ValuesController(Mock.Of<IOptions<SECOptions>>());
        }
        
        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _valueController.Get(3);

            Assert.Equal(result, $"value");
            
        }
    }
}