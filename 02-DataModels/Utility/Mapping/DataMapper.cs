using Mapster;
using MapsterMapper;

namespace DataModels.Utility.Mapping;

internal sealed class DataMapper : ServiceMapper, IDataMapper
{
    public DataMapper(IServiceProvider serviceProvider, TypeAdapterConfig config)
        : base(serviceProvider, config)
    {
    }
}
