using LogicalModels.UserAggregate.ValueObjects;

namespace LogicalModels.UserAggregate.Entities;

public sealed class User
{
    private User()
    {}

    public int Id { get; private set; }
    public FullName FullName { get; private set; } = FullName.Default;
    public Email Email { get; private set; } = Email.Default;

    public static User Create(string fullName, string email)
    {
        var user = new User
        {
            FullName = fullName,
            Email = email,
        };

        return user;
    }
}
