using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

/// <summary>
/// used for executing actions
/// </summary>
public class Parameter : IHasId
{
    public Guid ParameterTypId { get; set; }
    public string Value { get; set; }
    public Guid Id { get; set; }
}