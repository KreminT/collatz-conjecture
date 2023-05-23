using CollatzConjecture.Math.IO.Args;

namespace CollatzConjecture.Math.IO;

public class ResultProcessor : IResultProcessor
{
    private List<string> _results = new List<string>();

    Task IResultProcessor.Write(string result)
    {
        _results.Add(result);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<string>> GetResults(IResultProcessingArgs args)
    {
        return Task.FromResult(_results.GetBetween(args.StartInterval,args.EndInterval));
    }
}