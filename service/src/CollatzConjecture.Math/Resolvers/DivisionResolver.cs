using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Resolvers;

public class DivisionResolver : IMathResolver
{
    public Task<MathResult> Resolve(NumericPart item, MathResult prevResult = null)
    {
        string res = string.Empty;
        if (item.Value > 1)
        {
            res = ((int)item.Value / 2).ToString();
            if (item.ValueString[0] == '0')
                res = AddZerosIfExists(res, item.ValueString);
        }
        else
            res = res.AddZeros(item.ValueString.Length);

        return Task.FromResult(new MathResult() { Result = res });
    }

    private string AddZerosIfExists(string number, string prevLine)
    {
        for (int i = 0; i < prevLine.Length; i++)
        {
            if (prevLine[i] == '0')
            {
                number = number.Insert(0, "0");
            }
            else
                break;
        }
        return number;
    }
}