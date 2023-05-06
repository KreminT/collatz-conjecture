namespace CollatzConjecture.Math.Model;

public interface IResolverArgs
{
    public string Value { get; set; }
    public int Multiplier { get; set; }
    public int MaxIteration { get; set; }

    public bool IsSubtraction { get; set; }
    public int StartInterval { get; set; }
    public int EndInterval { get; set; }
}