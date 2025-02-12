using System.Diagnostics;
using CollatzConjecture.Math.Calc;
using CollatzConjecture.Math.Converters;
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
            Mock<IResolverConfiguration> configuration = new Mock<IResolverConfiguration>();
            configuration.Setup(item => item.NumberLength).Returns(6);
            _resolver = new CollatzConjectureResolver(new CollatzMathService(new CollatzCalc(), new DivisionConverter(configuration.Object), new MultiplicationConverter(configuration.Object)));
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

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _resolver.ResolveConjecture(argsMock.Object, processor);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
           
            List<string> result = (await processor.GetResults(_args.Object)).ToList();
            Assert.Equal(277, result.Count);
            Assert.Equal("24324324334", result[6]);
           
            stopwatch.Reset();

            BigIntegerCollatzConjectureResolver bigIntegerCollatzConjecture = new BigIntegerCollatzConjectureResolver();
            processor = new ResultProcessor();

            stopwatch.Start();
            await bigIntegerCollatzConjecture.ResolveConjecture(argsMock.Object, processor);
            stopwatch.Stop();

            result = (await processor.GetResults(_args.Object)).ToList();
            Assert.Equal(277, result.Count);
            Assert.Equal("24324324334", result[6]);
            Assert.True(time > stopwatch.ElapsedMilliseconds);
        }

        [Fact]
        public async Task ResolveLargeTest()
        {
            Mock<IResolverArgs> argsMock = new Mock<IResolverArgs>();
            argsMock.Setup(item => item.Value).Returns("7483264783698157642965743657849637564205842057840275846257439657426574628504296565893076845276546257428437619058402985647286758036117875180617865741657419657392675426957426751467541657946195642965472865479826571965714657841657843265746291765417856491574165741659784165748265784265784176589416587416574612975461975461956741058741058416578843157647156471964587158416756478865149876517946571467816547186597416510987567416541765471965714657814651789654781654781654732651874651798564189756418795641785614879564179865716587165741659718659467519");
            argsMock.Setup(item => item.Multiplier).Returns(3);
            argsMock.Setup(item => item.MaxIteration).Returns(0);
            ResultProcessor processor = new ResultProcessor();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _resolver.ResolveConjecture(argsMock.Object, processor);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
           
            List<string> result = (await processor.GetResults(_args.Object)).ToList();
            Assert.Equal(12960, result.Count);
           
            stopwatch.Reset();

            BigIntegerCollatzConjectureResolver bigIntegerCollatzConjecture = new BigIntegerCollatzConjectureResolver();
            processor = new ResultProcessor();

            stopwatch.Start();
            await bigIntegerCollatzConjecture.ResolveConjecture(argsMock.Object, processor);
            stopwatch.Stop();

            result = (await processor.GetResults(_args.Object)).ToList();
            Assert.Equal(12960, result.Count);
            Assert.True(time > stopwatch.ElapsedMilliseconds);
        }

        [Fact]
        public async Task ResolveLargeDynamicTest()
        {
            Mock<IResolverArgs> argsMock = new Mock<IResolverArgs>();
            string value = GetRandomNumber(1000);
            argsMock.Setup(item => item.Value).Returns(value);
            argsMock.Setup(item => item.Multiplier).Returns(3);
            argsMock.Setup(item => item.MaxIteration).Returns(0);
            ResultProcessor processor = new ResultProcessor();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _resolver.ResolveConjecture(argsMock.Object, processor);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
           
            List<string> result = (await processor.GetResults(_args.Object)).ToList();
            int expectedCount = result.Count;
           
            stopwatch.Reset();

            BigIntegerCollatzConjectureResolver bigIntegerCollatzConjecture = new BigIntegerCollatzConjectureResolver();
            processor = new ResultProcessor();

            stopwatch.Start();
            await bigIntegerCollatzConjecture.ResolveConjecture(argsMock.Object, processor);
            stopwatch.Stop();

            result = (await processor.GetResults(_args.Object)).ToList();
            Assert.Equal(expectedCount, result.Count);
            Assert.True(time > stopwatch.ElapsedMilliseconds);
        }

        string GetRandomNumber(int length)
        {
            string value = string.Empty;
            for (int i = 0; i < length; i++)
            {
                Random random = new Random();
                value += random.Next(0, 9);
            }
            return value;
        }

        [Fact]
        public async Task ResolveWithBigMultiplierTest()
        {
            Mock<IResolverArgs> argsMock = new Mock<IResolverArgs>();
            argsMock.Setup(item => item.Value).Returns("43243243256");
            argsMock.Setup(item => item.Multiplier).Returns(99);
            argsMock.Setup(item => item.MaxIteration).Returns(10000);
            ResultProcessor processor = new ResultProcessor();
            await _resolver.ResolveConjecture(argsMock.Object, processor);
            List<string> result = (await processor.GetResults(_args.Object)).ToList();
        }
    }
}
