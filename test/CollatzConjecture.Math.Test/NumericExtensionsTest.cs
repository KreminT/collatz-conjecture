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
        public void SplitNumericToPartsWithNotFullLastTest()
        {
            string number = "4564789";
            var parts = number.SplitNumericToParts(3);
            Assert.NotEmpty(parts);
            Assert.Equal(3, parts.Count);
            Assert.Equal("456", parts[0]);
            Assert.Equal("478", parts[1]);
            Assert.Equal("9", parts[2]);
        }

        [Fact]
        public void SplitNumericToPartsWithFullLastTest()
        {
            string number = "456478";
            var parts = number.SplitNumericToParts(3);
            Assert.NotEmpty(parts);
            Assert.Equal(2, parts.Count);
            Assert.Equal("456", parts[0]);
            Assert.Equal("478", parts[1]);
        }

        [Fact]
        public void SplitNumericToPartsLineShorterThanPartTest()
        {
            string number = "45";
            var parts = number.SplitNumericToParts(3);
            Assert.NotEmpty(parts);
            Assert.Single(parts);
            Assert.Equal("45", parts[0]);
        }

        [Fact]
        public void SplitNumericToPartsLineIsNullTest()
        {
            string number = null;
            var parts = number.SplitNumericToParts(3);
            Assert.Empty(parts);
        }

        [Fact]
        public void SplitNumericToPartsWithAddOneToBeginTest()
        {
            string number = "21621621628";
            var parts = number.SplitNumericToParts(8,true);
            Assert.NotEmpty(parts);
            Assert.Equal(2, parts.Count);
            Assert.Equal("21621621", parts[0]);
            Assert.Equal("1628", parts[1]);
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
