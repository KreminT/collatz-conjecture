namespace CollatzConjecture.Math
{
    public interface ICollatzMathService
    {
        Task<string> DivisionBy2(string number);
        string Multiplication(string number, int multiplier);
    }
}
