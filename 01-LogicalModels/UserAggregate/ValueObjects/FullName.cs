namespace LogicalModels.UserAggregate.ValueObjects;

public readonly record struct FullName
{
    private readonly string _value;

    public FullName(string value)
    {
        Validate(value);
        _value = value;
    }

    public string GetValue()
    {
        return _value;
    }

    public static FullName Default => "Default";

    private static void Validate(string value)
    {
        if (value is null || value.Length <= 2 || value.Length > 200)
        {
            throw new Exception("Name is invalid");
        }
    }

    public static implicit operator FullName(string value)
    {
        return new FullName(value);
    }

    public static implicit operator string(FullName name)
    {
        return name._value;
    }

    public override string ToString()
    {
        return _value;
    }
}