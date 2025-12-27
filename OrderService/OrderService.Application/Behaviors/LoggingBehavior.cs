using MediatR;
using Serilog;
using System.Diagnostics;

namespace OrderService.Application.Behaviors
{
    public class LoggingBehavior<TReq, TRes>
        : IPipelineBehavior<TReq, TRes>
    {
        private readonly ILogger _logger;

        public LoggingBehavior()
        {
            // Serilog global logger
            _logger = Log.ForContext<LoggingBehavior<TReq, TRes>>();
        }

        public async Task<TRes> Handle(
            TReq request,
            RequestHandlerDelegate<TRes> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TReq).Name;
            var stopwatch = Stopwatch.StartNew();

            _logger.Information(
                "Handling {RequestName} {@Request}",
                requestName,
                request
            );

            try
            {
                var response = await next();

                stopwatch.Stop();

                _logger.Information(
                    "Handled {RequestName} in {ElapsedMilliseconds} ms {@Response}",
                    requestName,
                    stopwatch.ElapsedMilliseconds,
                    response
                );

                return response;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                _logger.Error(
                    ex,
                    "Error handling {RequestName} after {ElapsedMilliseconds} ms {@Request}",
                    requestName,
                    stopwatch.ElapsedMilliseconds,
                    request
                );

                throw;
            }
        }
    }
}
