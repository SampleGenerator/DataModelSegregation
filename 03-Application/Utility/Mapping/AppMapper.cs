using Mapster;
using MapsterMapper;

namespace Application.Utility.Mapping;

internal sealed class AppMapper : ServiceMapper, IAppMapper
{
    public AppMapper(IServiceProvider serviceProvider, TypeAdapterConfig config)
        : base(serviceProvider, config)
    {
    }
}
