using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IActionParameterMapper<ToType>
{
    ToType Map(ActionConfiguration configurtaion);
}