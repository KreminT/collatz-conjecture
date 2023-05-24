using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Calc;

public class CollatzCalc
{
    public Task<CalculationResult> Division(NumericPart item)
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

        return Task.FromResult(new CalculationResult() { Result = res });
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

    public Task<CalculationResult> Multiplication(MultiplicationArgs args)
    {
        CalculationResult result = new CalculationResult();
        int value = args.NumericPart.Value * args.Multiplier;
        if (args.NumericPart.Next == null)
        {
            if (args.IsSubtraction)
                value -= 1;
            else
                value += 1;
        }
        value += args.PrevResult?.Remainder ?? 0;
        string val = value.ToString();
        val = val.AddZeros(args.NumericPart.ValueString.Length);
        if (val.Length > args.NumericPart.ValueString.Length)
            result.Remainder = int.Parse(val.Substring(0, val.Length - args.NumericPart.ValueString.Length));

        result.Result = val;
        return Task.FromResult(result);
    }
}