namespace CollatzConjecture.Math.Exception
{
    public class NotNumericException : ArgumentException
    {
        public NotNumericException(string number) : base($"{number} isn't a numeric value")
        {

        }
    }
}
