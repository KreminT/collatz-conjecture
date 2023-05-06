namespace CollatzConjecture.Math.IO;

public interface IFileResultProcessor : IResultProcessor
{
    string GetFileName();
    Task<Stream> GetStream(int? startIndex,int? endIndex);
}