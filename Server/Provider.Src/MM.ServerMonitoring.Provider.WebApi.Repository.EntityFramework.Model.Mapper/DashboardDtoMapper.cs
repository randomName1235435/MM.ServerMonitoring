using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;

namespace MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Model.Mapper;

public class DashboardDtoMapper : MapperBase<Dashboard, DashboardDto>, IOneWayMapper<DashboardDto, Dashboard>
{
}