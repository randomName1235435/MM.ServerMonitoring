using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

public class TargetDto : IHasId, IHasName
{
    public TargetTypDto TargetTyp { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}