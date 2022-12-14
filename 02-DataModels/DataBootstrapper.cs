using DataModels.UserAggregate;
using DataModels.Utility;
using DataModels.Utility.Mapping;
using LogicalModels.UserAggregate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataModels;

public static class DataBootstrapper
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDataLayerMapper();

        services.AddDbContext<AppDbContext>(
            opt => opt.UseInMemoryDatabase("EShop")
            //opt => opt.UseSqlServer(connectionString)
        );

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, AppUnitOfWork>();

        return services;
    }
}