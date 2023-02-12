namespace CollatzConjecture.Math.IO
{
    public interface IResultProcessor
    {
        string GetFileName();
        public void Write(string result);
    }
}
