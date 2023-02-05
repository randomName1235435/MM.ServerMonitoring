using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

public class ParameterTyp : IHasName, IHasDescription, IHasId
{
    public string Description { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}