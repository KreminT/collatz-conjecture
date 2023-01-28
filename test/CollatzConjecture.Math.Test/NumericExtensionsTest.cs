using Xunit;

namespace CollatzConjecture.Math.Test
{
    public class NumericExtensionsTest
    {
        [Fact]
        public void IsNumeric()
        {
            Assert.True("34247382754397564798654972657984265794265796492765928".IsNumeric());
            Assert.True("4320943828946503234892342".IsNumeric());
            Assert.False("432u9884329".IsNumeric());
            Assert.False("4327843728473+32432".IsNumeric());
        }
    }
}
