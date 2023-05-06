namespace CollatzConjecture.Math.IO
{
    public interface IResultProcessor
    {
        public Task Write(string result);

        public Task<IEnumerable<string>> GetResults();
    }
}
