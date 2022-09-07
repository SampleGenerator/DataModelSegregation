using LogicalModels.UserAggregate.Entities;
using System.Reflection;

namespace DataModels.UserAggregate;

internal sealed class UserData
{
    private UserData()
    { }

    public int Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
}
