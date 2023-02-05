using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Model;

public class Action : IHasDescription, IHasName, IHasId
{
    public string Description { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}
//todo satic analyysis run on sln