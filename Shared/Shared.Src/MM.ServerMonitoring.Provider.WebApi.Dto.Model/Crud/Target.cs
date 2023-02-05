using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

/// <summary>
/// organize groups for server, webpages, vm ..
/// </summary>
public class Target : IHasId
{
    public Guid TargetTypId { get; set; }

    public string Name { get; set; }

    public Guid Id { get; set; }
}