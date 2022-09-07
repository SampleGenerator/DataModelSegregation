namespace Application.Utility.Mapping;

public static class AppMapperBootsrapper
{
    public static IServiceCollection AddAppLayerMapper(this IServiceCollection services)
    {
        services.AddSingleton(p =>
        {
            var config = new AppMapperTypeAdapterConfig();
            return config;
        });

        services.AddScoped<IAppMapper, AppMapper>(p =>
        {
            var config = p.GetRequiredService<AppMapperTypeAdapterConfig>();
            return new AppMapper(p, config);
        });

        return services;
    }
}
