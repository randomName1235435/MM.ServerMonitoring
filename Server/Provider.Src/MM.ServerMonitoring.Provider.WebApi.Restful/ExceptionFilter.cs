using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;

namespace MM.ServerMonitoring.Provider.WebApi.Restful;

/// <summary>
///     note: system.text.json serializer cant serialize exception, so don't use them as content/response
/// </summary>
public class ExceptionFilter : ExceptionFilterAttribute
{
    private static readonly List<Tuple<Type, Func<Exception, ObjectResult>>>
        Handlers = new();

    private readonly ILogger logger;

    //todo add logging pls
    static ExceptionFilter()
    {
        RegisterHandler<ValidationFailedException>(CreateResponse);
        RegisterHandler<ItemNotFoundException>(CreateResponse);
        RegisterHandler<ArgumentNullException>(CreateResponse);
        RegisterHandler<ArgumentException>(CreateResponse);
        RegisterHandler<InvalidStateException>(CreateResponse);
        RegisterHandler<Exception>(CreateResponse);
        RegisterHandler<OperationCanceledException>(CreateResponse);
    }

    public override void OnException(ExceptionContext context)
    {
        var exceptionType = context.Exception.GetType();

        foreach (var handler in Handlers)
        {
            var keyType = handler.Item1;
            var handle = handler.Item2;

            if (!keyType.IsAssignableFrom(exceptionType)) continue;

            var result = handle(context.Exception);
            context.HttpContext.Response.StatusCode = (int)result.StatusCode;
            // this.LogResponse(context.Exception, desc);
            context.Result = result;
            return;
        }
        //todo
        // this.logger.Error($"Exception not filtered, type: {exceptionType}");
    }

    private void LogResponse(Exception ex, ObjectResult x)
    {
        //todo
        //var statusCode = x.StatusCode;
        //var reasonPhrase = x.ReasonPhrase;
        //var content = x.Content;

        //var level =
        //    ((int)statusCode < 300) ? Level.Trace
        //    : (400 <= (int)statusCode && (int)statusCode < 500) ? Level.Warn
        //    : (500 <= (int)statusCode && (int)statusCode < 600) ? Level.Error
        //    : Level.Debug;

        //this.logger.Log(level, ex, $"Exception filtered. Response: ({statusCode}, {reasonPhrase}, {content})");
    }

    private static void RegisterHandler<T>(Func<T, ObjectResult> f)
    {
        Handlers.Add(Tuple.Create(typeof(T),
            new Func<Exception, ObjectResult>(x => f((T)(object)x))));
    }

    private static ObjectResult CreateResponse(OperationCanceledException ex)
    {
        var content = JsonSerializer.Serialize(ex.Message);

        return new ObjectResult(content)
        {
            StatusCode = (int)HttpStatusCode.Conflict
        };
    }

    //todo replace exceptions as content with generic phrases
    private static ObjectResult CreateResponse(ValidationFailedException ex)
    {
        var content = JsonSerializer.Serialize(ex.Message);
        return new BadRequestObjectResult(content);
    }

    private static ObjectResult CreateResponse(ItemNotFoundException ex)
    {
        return new ObjectResult(ex.Message)
        {
            StatusCode = (int)HttpStatusCode.NotFound
        };
    }


    private static ObjectResult CreateResponse(ArgumentNullException ex)
    {
        return new ObjectResult(ex.Message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }

    private static ObjectResult CreateResponse(InvalidStateException ex)
    {
        return new ObjectResult(ex.Message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }

    private static ObjectResult CreateResponse(ArgumentException ex)
    {
        return new ObjectResult(ex.Message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }

    private static ObjectResult CreateResponse(Exception ex)
    {
#if DEBUG
        return new ObjectResult(ex.Message)
#else
        return new ObjectResult("internal error :(")
#endif
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}