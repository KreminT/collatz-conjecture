using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void ResolveTest()
        {
            var result = _resolver.ResolveConjecture("43243243256");
            Assert.Equal(277, result.Count);
            Assert.Equal("24324324334", result[6]);
        }
    }
}
