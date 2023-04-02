using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Converters;

public class MultiplicationConverter : LongNumberConverter
{
    protected override string Prepare(string number, LongNumber longNumber)
    {
        return number;
    }
}