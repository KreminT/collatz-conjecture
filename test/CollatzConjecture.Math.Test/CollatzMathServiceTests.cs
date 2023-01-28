using CollatzConjecture.Math.Exception;
using Xunit;

namespace CollatzConjecture.Math.Test
{
    public class CollatzMathServiceTests
    {
        [Fact]
        public void Math3XTest()
        {
            CollatzMathService mathService = new CollatzMathService();

            Assert.Throws<NotNumericException>(()=>mathService.Math3X("48,974,897"));
            Assert.Equal("146924692", mathService.Math3X("48974897"));
            Assert.Equal("13327297298229729730", mathService.Math3X("4442432432743243243"));
            Assert.Equal("22458979439497942177942096", mathService.Math3X("7486326479832647392647365"));
        }
    }
}
