using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.ActionExecutor.EntityFramework.Model.Mapper;

public class MonitorMapper : IMapper<Monitor, MonitorConfiguration>
{
    private readonly IRepository<Action> actionRepository;
    private readonly IRepository<Parameter> parameterRepository;
    private readonly IRepository<ParameterTyp> parameterTypRepository;

    private System.Action initializeCache;
    private Dictionary<Guid, string> parametertypIdNameCache;


    public MonitorMapper(
        IRepository<Action> actionRepository,
        IRepository<Parameter> parameterRepository,
        IRepository<ParameterTyp> parameterTypRepository)
    {
        _ = actionRepository ?? throw new ArgumentNullException();
        _ = parameterRepository ?? throw new ArgumentNullException();
        _ = parameterTypRepository ?? throw new ArgumentNullException();

        this.actionRepository = actionRepository;
        this.parameterRepository = parameterRepository;
        this.parameterTypRepository = parameterTypRepository;

        this.initializeCache = this.InitParametertypCache;
    }

    public Dictionary<Guid, string> ParametertypIdNameCache
    {
        get
        {
            this.initializeCache();
            return this.parametertypIdNameCache;
        }
    }

    public MonitorConfiguration Map(Monitor input,
        Func<MonitorConfiguration> @default = null)
    {
        var action = this.actionRepository.FindById(input.ActionId);
        var parametertypCollection = this.parameterTypRepository.Read();
        var paramCollection = this.parameterRepository.Read(q => q.Where(item => item.Id == input.ParameterId));

        return new MonitorConfiguration
        {
            MonitorId = input.Id,
            MonitorName = input.Name,
            Timeout = TimeSpan.FromMilliseconds(1000),
            ActionConfiguration =
                new ActionConfiguration
                {
                    ActionId = input.ActionId,
                    ActionName = action.Name,
                    Timeout = TimeSpan.FromMilliseconds(1000),
                    ParameterCollection = paramCollection.ToDictionary(
                        item => ParametertypIdNameCache[item.ParameterTypId],
                        item => item.Value)
                }
            //Timeout = 
            //ActionId = input.ActionId,
            //Description = input.Description,

            //Name = ,
            //TargetId = input.TargetId
        };
    }

    private void InitParametertypCache()
    {
        this.parametertypIdNameCache = this.parameterTypRepository.Read().ToDictionary(
            item => item.Id,
            item => item.Name
        );
        this.initializeCache = () => { };
    }
}