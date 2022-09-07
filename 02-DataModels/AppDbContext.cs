using DataModels.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataModels;

internal sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Users = Set<UserData>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<UserData> Users { get; set; }
}

