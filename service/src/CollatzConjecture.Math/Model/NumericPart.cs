namespace CollatzConjecture.Math.Model;

public class NumericPart
{
    public int Value { get; }
    public string ValueString { get; }
    public NumericPart? Prev { get; }
    public NumericPart? Next { get; protected set; }

    public NumericPart(string value, NumericPart prev)
    {
        Prev = prev;
        ValueString = value;
        Value = Int32.Parse(value);
    }

    public void AddNext(string value)
    {
        Next = new NumericPart(value, this);
    }

    public bool IsEven()
    {
        return ValueString?.IsEven() ?? false;
    }
}