using Microsoft.Extensions.Logging;
using MyCouch;
using Nancy;
using System.Threading.Tasks;
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
        }

        private async Task<object> SayHello(dynamic ct)
        {
            string name;

            using (var client = new MyCouchClient("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {
                /* var put = await client.Entities.PutAsync(
                     new Person { Id = "001", Name = "Daniel" });
                */

                var get = await client.Entities.GetAsync<Person>("001");
                name = get.Content.Name;
            }

            return "hello from home module "+ name;
        }
    }
}