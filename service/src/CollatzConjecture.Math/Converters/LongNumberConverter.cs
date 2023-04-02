using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Converters;

public abstract class LongNumberConverter
{
    public LongNumber ConvertToLongNumber(string number, int length)
    {
        LongNumber longNumber = new LongNumber();
        if (string.IsNullOrEmpty(number))
            return longNumber;
        string line = String.Empty;
        int iteration = 0;
        foreach (var item in number)
        {
            line += item;
            iteration++;
            if (iteration == length)
            {
                longNumber.Add(Prepare(line, longNumber));
                line = String.Empty;
                iteration = 0;
            }
        }
        if (iteration < length && !string.IsNullOrEmpty(line))
            longNumber.Add(Prepare(line, longNumber));
        return longNumber;
    }
    protected abstract string Prepare(string number, LongNumber longNumber);
}