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
            Assert.False("4327843728473 32432".IsNumeric());
        }

        [Fact]
        public void IsEvenTests()
        {           
            Assert.True("243278473856487395764938".IsEven());
            Assert.True("24343278475984976578926547265798425948726754892".IsEven());
            Assert.False("24343278475984976578926547265798425948726754893".IsEven());
            Assert.False("23".IsEven());
            Assert.True("32".IsEven());
        }

        [Fact]
        public void AddZerosTests()
        {
            Assert.Equal("001", "1".AddZeros(3));
            Assert.Equal("011", "11".AddZeros(3));
            Assert.Equal("111", "111".AddZeros(3));
        }
    }
}
