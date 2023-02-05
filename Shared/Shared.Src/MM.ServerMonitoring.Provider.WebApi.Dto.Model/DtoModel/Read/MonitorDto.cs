using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

public class MonitorDto : IHasId, IHasDescription, IHasName
{
    public TargetDto Target { get; set; }
    public ActionDto Action { get; set; }
    public ParameterDto Parameter { get; set; }
    public string Description { get; set; }
    public Guid Id { get; init; }
    public string Name { get; set; }
}