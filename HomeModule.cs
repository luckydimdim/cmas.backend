using Microsoft.Extensions.Logging;
using Nancy;

namespace cmas.backend
{
    public class HomeModule : NancyModule
    {
        private ILogger _logger;

        public HomeModule(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeModule>();
            _logger.LogInformation("test log");

            Get("/", _ => "Hello from cmas.backend component!");
        }
    }
}
