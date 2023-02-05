using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Model;

public class Parameter : IHasId, IHasParameterTypId
{
    public string Value { get; }

    public ParameterTyp ParameterTyp { get; set; }
    public Guid Id { get; }
    public Guid ParameterTypId { get; } // todo typ? or maybe parameter & parametervalue?
}