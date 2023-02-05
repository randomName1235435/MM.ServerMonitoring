using Microsoft.AspNetCore.Http.Extensions;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers;

public class Log<TController> : IDisposable
{
    private readonly Action logAction;

    /// <summary>
    ///     info log after api call by using
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="httpRequest"></param>
    protected Log(ILogger<TController> logger, HttpRequest httpRequest)
    {
        _ = logger ?? throw new ArgumentNullException(nameof(logger));

        this.logAction = () => logger.LogInformation("requested api call [url={0}]", httpRequest.GetDisplayUrl());
    }

    public void Dispose()
    {
        this.logAction();
    }

    public static Log<TController> InfoApiCall<TController>(ILogger<TController> logger, HttpRequest httpRequest)
    {
        return new Log<TController>(logger, httpRequest);
    }
}