using CollatzConjecture.Math.IO.Args;

namespace CollatzConjecture.Math.IO;

public interface IFileResultProcessor : IResultProcessor
{
    string GetFileName();
    Task<Stream> GetStream(IFileResultProcessingArgs args);
}