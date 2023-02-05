using System.Net;
using MM.ServerMonitoring.ActionExecutor.Infrastructure;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Actions.HttpRequest;

public class ActionHttpRequest : IAction
{
    private readonly ActionConfiguration configuration;
    private readonly ActionHttpRequestParameter parameter;

    public ActionHttpRequest(ActionConfiguration configuration,
        IActionParameterMapper<ActionHttpRequestParameter> actionParameterMapper)
    {
        _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

        this.configuration = configuration;
        this.parameter = actionParameterMapper.Map(configuration);
    }

    public async Task<ActionExecutionResult> ExecuteAsync(CancellationToken token)
    {
        var start = DateTime.Now;
        try
        {
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(this.configuration.Timeout.TotalMilliseconds.AsIntOrMax());

            using var response = await httpClient.GetAsync(this.parameter.Url, token);
            var statusCode = response.StatusCode;
            if (statusCode == HttpStatusCode.OK)
                return this.CreateResult(true, string.Empty, start);
            return this.CreateResult(false, statusCode.ToString(), start);
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
            Target = this.parameter.Url,
            Messages = message is null ? Array.Empty<string>() : new[] { message }
        };
    }
}