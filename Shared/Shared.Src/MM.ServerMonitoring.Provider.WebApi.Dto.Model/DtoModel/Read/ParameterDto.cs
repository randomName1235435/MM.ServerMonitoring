using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

public class ParameterDto : IHasId
{
    public ParameterTypDto ParameterTyp { get; set; }
    public string Value { get; set; }
    public Guid Id { get; set; }
}