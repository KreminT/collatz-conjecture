using CollatzConjecture.Math.IO;

namespace CollatzConjecture.Math
{
    public interface ICollatzConjectureResolver
    {
        Task<List<string>> ResolveConjecture(string number);
        Task<string> ResolveConjecture(string number, IResultProcessor processor);
    }
}
