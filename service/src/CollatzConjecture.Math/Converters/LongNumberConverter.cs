using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Converters;

public abstract class LongNumberConverter
{
    private readonly IResolverConfiguration _configuration;

    public LongNumberConverter(IResolverConfiguration configuration)
    {
        _configuration = configuration;
    }

    public LongNumber ConvertToLongNumber(string number)
    {
        LongNumber longNumber = new LongNumber();
        if (string.IsNullOrEmpty(number))
            return longNumber;
        number = number.Replace(" ", "");
        string line = String.Empty;
        int iteration = 0;
        foreach (var item in number)
        {
            line += item;
            iteration++;
            if (iteration == _configuration.NumberLength)
            {
                longNumber.Add(Prepare(line, longNumber));
                line = String.Empty;
                iteration = 0;
            }
        }
        if (iteration < _configuration.NumberLength && !string.IsNullOrEmpty(line))
            longNumber.Add(Prepare(line, longNumber));
        return longNumber;
    }
    protected abstract string Prepare(string number, LongNumber longNumber);
}