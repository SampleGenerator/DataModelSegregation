using System.Text.RegularExpressions;

namespace LogicalModels.UserAggregate.ValueObjects;

public readonly record struct Email
{
    private readonly string _value;

    public Email(string value)
    {
        Validate(value);
        _value = value;
    }

    public static string Default => "default@default.com";

    public string GetValue()
    {
        return _value;
    }

    private static void Validate(string value)
    {
        Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(value);
        if (!match.Success)
        {
            throw new Exception("Email is invalid");
        }
    }

    public static implicit operator Email(string value)
    {
        return new Email(value);
    }

    public static implicit operator string(Email email)
    {
        return email._value;
    }

    public override string ToString()
    {
        return _value;
    }
}
