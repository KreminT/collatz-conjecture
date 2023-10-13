using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Converters;

public class DivisionConverter : LongNumberConverter
{
    protected override string Prepare(string number, LongNumber longNumber)
    {
        if (longNumber.GetLast() != null && !longNumber.IsEven())
            number = number.Insert(0, "1");
        else if ((number[0] == '1' || IsAddZero(number)) && longNumber.GetLast() != null)
            number = number.Insert(0, "0");
        return number;
    }

    private static bool IsAddZero(string line)
    {
        bool isAddZero = false;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i].Equals('0'))
            {
                isAddZero = true;
                continue;
            }
            if (line[i].Equals('1') && isAddZero && line.Length > i + 1)
                return true;
            return false;
        }
        return false;
    }

    public DivisionConverter(IResolverConfiguration configuration) : base(configuration)
    {
    }
}