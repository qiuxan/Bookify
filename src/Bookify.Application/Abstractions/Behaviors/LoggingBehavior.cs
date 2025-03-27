using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken
        )
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing command {Name}", name);
            var result = await next();
            _logger.LogInformation("Command {Name} processed successfully", name);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error handling {Name}", name);
            throw;

        }
    }
}
