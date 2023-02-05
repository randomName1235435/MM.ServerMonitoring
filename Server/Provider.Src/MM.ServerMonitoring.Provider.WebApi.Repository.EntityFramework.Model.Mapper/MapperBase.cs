using AutoMapper;
using MM.ServerMonitoring.Provider.WebApi.Interface;

namespace MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Model.Mapper;

public class MapperBase<T1, T2> : IMapper<T1, T2>
{
    private readonly IMapper innerMapper;

    public MapperBase()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<T1, T2>();
            cfg.CreateMap<T2, T1>();
        });
        this.innerMapper = config.CreateMapper();
    }

    public virtual T1 Map(T2 input, Func<T1> @default = null)
    {
        return this.innerMapper.Map<T1>(input);
    }

    public virtual T2 Map(T1 input, Func<T2> @default = null)
    {
        return this.innerMapper.Map<T2>(input);
    }
}