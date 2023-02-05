using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

public class Monitor : IHasName, IHasDescription, IHasId
{
    public Guid ActionId { get; set; }
    public Guid TargetId { get; set; }
    public Guid ParameterId { get; set; }
    public string Description { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}