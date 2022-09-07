namespace DataModels.UserAggregate;

internal sealed class UserData
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
}
