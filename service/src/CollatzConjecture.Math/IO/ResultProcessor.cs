namespace CollatzConjecture.Math.IO;

public class ResultProcessor : IResultProcessor
{
    private List<string> _results = new List<string>();

    public Task<IEnumerable<string>> GetResults()
    {
        return Task.FromResult((IEnumerable<string>)_results);
    }

    Task IResultProcessor.Write(string result)
    {
        _results.Add(result);
        return Task.CompletedTask;
    }
}