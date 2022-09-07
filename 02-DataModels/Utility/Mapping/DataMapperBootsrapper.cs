using Microsoft.Extensions.DependencyInjection;

namespace DataModels.Utility.Mapping;

public static class DataMapperBootsrapper
{
    public static IServiceCollection AddDataLayerMapper(this IServiceCollection services)
    {
        services.AddSingleton(p =>
        {
            var config = new DataMapperTypeAdapterConfig();
            return config;
        });

        services.AddScoped<IDataMapper, DataMapper>(p =>
        {
            var config = p.GetRequiredService<DataMapperTypeAdapterConfig>();
            return new DataMapper(p, config);
        });

        return services;
    }
}
