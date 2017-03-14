using Microsoft.Extensions.Logging;
using Nancy;
using System.Threading.Tasks;
using error_handler.backend;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace cmas.backend
{
    public class HomeModule : NancyModule
    {
        private ILogger _logger;

        public class Person
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public HomeModule(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeModule>();
            _logger.LogInformation("test log");

            Get("/", SayHello);

            Get("token", (parameters, obj) =>
            {
                throw new InvalidTokenErrorException("The User had an invalid token.");
            });

            Get("unhandled", (parameters, obj) =>
            {
                throw new System.InvalidOperationException("An invalid operation exception.");
            });
        }

        private async Task<object> SayHello(dynamic ct)
        {
            return "hello from home module ";
        }
    }
}