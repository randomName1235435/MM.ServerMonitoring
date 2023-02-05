using System.Net;
using System.Net.NetworkInformation;
using MM.ServerMonitoring.ActionExecutor.Infrastructure;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Actions.PingAction;

public class ActionPing : IAction
{
    private readonly ActionConfiguration configuration;
    private readonly ActionPingParameter parameter;

    public ActionPing(ActionConfiguration configuration,
        IActionParameterMapper<ActionPingParameter> actionParameterMapper)
    {
        _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

        this.configuration = configuration;
        this.parameter = actionParameterMapper.Map(configuration);
    }

    public async Task<ActionExecutionResult> ExecuteAsync(CancellationToken token)
    {
        PingReply reply;
        var start = DateTime.Now;
        try
        {
            var ip = IPAddress.Parse(this.parameter.PingTarget);

            var ping = new Ping();
            reply = await ping.SendPingAsync(ip, this.configuration.Timeout.TotalMilliseconds.AsIntOrMax());
            if (reply.Status == IPStatus.Success)
                return this.CreateResult(true, string.Empty, start);
            return this.CreateResult(false, reply.Status.ToString(), start);
        }
        catch (TaskCanceledException e)
        {
            return this.CreateResult(false, e.Message, start);
        }
        catch (FormatException e)
        {
            throw e;
        }
        catch (Exception e)
        {
            return this.CreateResult(false, e.Message, start);
        }
    }

    private ActionExecutionResult CreateResult(bool success, string message, DateTime start)
    {
        return new ActionExecutionResult(success, start)
        {
            ActionId = this.configuration.ActionId,
            Target = this.parameter.PingTarget,
            Messages = message is null ? Array.Empty<string>() : new[] { message }
        };
    }
}