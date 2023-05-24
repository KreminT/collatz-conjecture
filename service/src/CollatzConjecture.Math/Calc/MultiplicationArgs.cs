using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Calc;

public class MultiplicationArgs
{
    public MultiplicationArgs(NumericPart numericPart, int multiplier, bool isSubtraction, CalculationResult prevResult)
    {
        NumericPart = numericPart;
        Multiplier = multiplier;
        IsSubtraction = isSubtraction;
        PrevResult = prevResult;
    }
    public NumericPart NumericPart { get; }
    public int Multiplier { get; }
    public bool IsSubtraction { get; }
    public CalculationResult PrevResult { get; }
}