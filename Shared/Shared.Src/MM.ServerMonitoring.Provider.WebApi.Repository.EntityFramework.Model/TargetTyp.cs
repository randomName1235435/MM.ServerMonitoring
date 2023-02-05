using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Model;

public class TargetTyp : IHasName, IHasDescription, IHasId
{
    public string Description { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}