using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Model;

public class Monitor : IHasDescription, IHasName, IHasId, IHasActionId, IHasTargetId, IHasParameterId
{
    public Action Action { get; set; }
    public Target Target { get; set; }
    public Parameter Parameter { get; set; }
    public Guid ActionId { get; set; }
    public string Description { get; set; }
    public Guid Id { get; init; }
    public string Name { get; set; }
    public Guid ParameterId { get; set; }
    public Guid TargetId { get; set; }
}