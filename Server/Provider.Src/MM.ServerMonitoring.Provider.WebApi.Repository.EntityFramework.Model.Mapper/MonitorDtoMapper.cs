using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Model.Mapper;

public class MonitorDtoMapper : IOneWayMapper<MonitorDto, Monitor>
{
    public MonitorDto Map(Monitor input, Func<MonitorDto> @default = null)
    {
        var mapped = new MonitorDto
        {
            Action = new ActionDto
            {
                Id = input.Action.Id,
                Name = input.Action.Name,
                Description = input.Action.Description
            },
            Target = new TargetDto
            {
                Id = input.Target.Id,
                Name = input.Target.Name,
                TargetTyp = new TargetTypDto
                {
                    Id = input.Target.TargetTyp.Id,
                    Name = input.Target.TargetTyp.Name,
                    Description = input.Target.TargetTyp.Description
                }
            },
            Id = input.Id,
            Description = input.Description,
            Name = input.Name,
            Parameter = new ParameterDto
            {
                Id = input.Parameter.Id,
                Value = input.Parameter.Value,
                ParameterTyp = new ParameterTypDto
                {
                    Id = input.Parameter.ParameterTyp.Id,
                    Name = input.Parameter.ParameterTyp.Name,
                    Description = input.Parameter.ParameterTyp.Description
                }
            }
        };
        return mapped;
    }
}