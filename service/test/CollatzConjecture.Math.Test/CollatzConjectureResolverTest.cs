using CollatzConjecture.Math.IO;
using CollatzConjecture.Math.IO.Args;
using CollatzConjecture.Math.Model;
using Moq;
using Xunit;

namespace CollatzConjecture.Math.Test
{
    public class CollatzConjectureResolverTest
    {
        private CollatzConjectureResolver _resolver;
        Mock<IFileResultProcessingArgs> _args;
        public CollatzConjectureResolverTest()
        {
            _resolver = new CollatzConjectureResolver(new CollatzMathService());
            _args = new Mock<IFileResultProcessingArgs>();
            _args.Setup(item => item.StartInterval).Returns((int?)null);
            _args.Setup(item => item.EndInterval).Returns((int?)null);
        }

        [Fact]
        public async Task ResolveTest()
        {
            Mock<IResolverArgs> argsMock = new Mock<IResolverArgs>();
            argsMock.Setup(item => item.Value).Returns("43243243256");
            argsMock.Setup(item => item.Multiplier).Returns(3);
            argsMock.Setup(item => item.MaxIteration).Returns(0);
            ResultProcessor processor = new ResultProcessor();
            await _resolver.ResolveConjecture(argsMock.Object, processor);
            List<string> result = (await processor.GetResults(_args.Object)).ToList();
            Assert.Equal(277, result.Count);
            Assert.Equal("24324324334", result[6]);
        }
    }
}
