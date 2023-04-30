using CollatzConjecture.Math.IO;
using Xunit;

namespace CollatzConjecture.Math.Test
{
    public class CollatzConjectureResolverTest
    {
        private CollatzConjectureResolver _resolver;
        public CollatzConjectureResolverTest()
        {
            _resolver = new CollatzConjectureResolver(new CollatzMathService());
        }

        [Fact]
        public async Task ResolveTest()
        {
            ResultProcessor processor = new ResultProcessor();
            await _resolver.ResolveConjecture("43243243256", 3,0, processor);
            List<string> result = (await processor.GetResults()).ToList();
            Assert.Equal(277, result.Count);
            Assert.Equal("24324324334", result[6]);
        }
    }
}
