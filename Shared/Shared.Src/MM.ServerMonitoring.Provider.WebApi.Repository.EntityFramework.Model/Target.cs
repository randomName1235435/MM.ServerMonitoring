using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Model;

public class Target : IHasId, IHasName, IHasTargetTypId
{
    public TargetTyp TargetTyp { get; set; }
    public Guid Id { get; }
    public string Name { get; set; }
    public Guid TargetTypId { get; }
}