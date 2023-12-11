using CollatzConjecture.Math.Converters;
using Moq;
using Xunit;

namespace CollatzConjecture.Math.Test;

public class ConverterTests
{
    [Fact]
    public void SplitNumericToPartsWithNotFullLastTest()
    {
        string number = "4564789";
        var parts = new MultiplicationConverter(PrepareConfiguration(3)).ConvertToLongNumber(number).ToList();

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
        var parts = new MultiplicationConverter(PrepareConfiguration(3)).ConvertToLongNumber(number).ToList();
        Assert.NotEmpty(parts);
        Assert.Equal(2, parts.Count);
        Assert.Equal("456", parts[0]);
        Assert.Equal("478", parts[1]);
    }

    [Fact]
    public void SplitNumericToPartsLineShorterThanPartTest()
    {
        string number = "45";
        var parts = new MultiplicationConverter(PrepareConfiguration(3)).ConvertToLongNumber(number).ToList();
        Assert.NotEmpty(parts);
        Assert.Single(parts);
        Assert.Equal("45", parts[0]);
    }

    [Fact]
    public void SplitNumericToPartsLineIsNullTest()
    {
        string number = null;
        var parts = new MultiplicationConverter(PrepareConfiguration(6)).ConvertToLongNumber(number).ToList();
        Assert.Empty(parts);
    }

    [Fact]
    public void SplitNumericToPartsWithAddOneToBeginTest()
    {
        string number = "21621621628";
        var parts = new DivisionConverter(PrepareConfiguration(8)).ConvertToLongNumber(number).ToList();
        Assert.NotEmpty(parts);
        Assert.Equal(2, parts.Count);
        Assert.Equal("21621621", parts[0]);
        Assert.Equal("1628", parts[1]);
    }

    private IResolverConfiguration PrepareConfiguration(int numberLength)
    {
        Mock<IResolverConfiguration> configuration = new Mock<IResolverConfiguration>();
        configuration.Setup(item => item.NumberLength).Returns(numberLength);
        return configuration.Object;
    }
}