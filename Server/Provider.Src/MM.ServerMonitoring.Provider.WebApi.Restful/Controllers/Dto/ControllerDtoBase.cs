using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Dto;

[ApiController]
public abstract class ControllerDtoBase<TController> : ControllerBase
{
    protected readonly ILogger<TController> logger;

    protected ControllerDtoBase(ILogger<TController> logger)
    {
        _ = logger ?? throw new ArgumentNullException(nameof(logger));

        this.logger = logger;
    }

    protected async Task<TResult> WithLogging<TResult>(Func<Task<TResult>> func)
    {
        try
        {
            using var log = Log<TController>.InfoApiCall(this.logger, Request);
            return await func();
        }
        catch (Exception ex)
        {
            this.logger.LogError("requested api call failed [url={0}, exception={1}]", Request.GetDisplayUrl(), ex);
            throw;
        }
    }
}