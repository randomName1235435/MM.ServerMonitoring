using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Model.Mapper;

public class MonitorActionExecutionDtoMapper : IOneWayMapper<MonitorActionExecutionDto, MonitorActionExecution>
{
    public MonitorActionExecutionDto Map(MonitorActionExecution input, Func<MonitorActionExecutionDto> @default = null)
    {
        var mapped = new MonitorActionExecutionDto
        {
            Action = new ActionDto
            {
                Id = input.Action.Id,
                Name = input.Action.Name,
                Description = input.Action.Description
            },
            Monitor = new MonitorFlatDto
            {
                Id = input.Monitor.Id,
                Name = input.Monitor.Name,
                Description = input.Monitor.Description
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
            Finish = input.Finish,
            Message = input.Message,
            Start = input.Start,
            WasSuccess = input.WasSuccess,
            Parameter = new ParameterDto
            {
                Id = input.Monitor.Parameter.Id,
                Value = input.Monitor.Parameter.Value,
                ParameterTyp = new ParameterTypDto
                {
                    Id = input.Monitor.Parameter.ParameterTyp.Id,
                    Name = input.Monitor.Parameter.ParameterTyp.Name,
                    Description = input.Monitor.Parameter.ParameterTyp.Description
                }
            }
        };
        return mapped;
    }
}