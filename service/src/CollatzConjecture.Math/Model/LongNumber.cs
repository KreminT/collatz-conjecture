namespace CollatzConjecture.Math.Model;

public class LongNumber
{
    private bool isInitialized = false;
    private NumericPart? _firstPart;
    private NumericPart? _lastPart;

    public void Add(string value)
    {
        if (!isInitialized)
        {
            _firstPart = new NumericPart(value, null);
            _lastPart = _firstPart;
            isInitialized = true;
        }
        else
        {
            _lastPart.AddNext(value);
            _lastPart = _lastPart.Next;
        }
    }

    public NumericPart? GetLast()
    {
        return _lastPart;
    }

    public bool IsEven()
    {
        return _lastPart?.IsEven() ?? false;
    }

    public NumericPart GetFirst()
    {
        return _firstPart;
    }

    public List<string> ToList()
    {
        NumericPart? item = _firstPart;
        List<string> values = new List<string>();
        while (item!=null)
        {
            values.Add(item.ValueString);
            item = item.Next;
        }
        return values;
    }
}