using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

public class Action : IHasId
{
    public string Description { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }
}
//todo satic analyysis run on sln