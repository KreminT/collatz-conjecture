namespace CollatzConjecture.Math
{
    public interface ICollatzMathService
    {
        Task<string> DivisionBy2(string number);
        Task<string> Multiplication(string number, int multiplier);
    }
}
