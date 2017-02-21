using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Nancy;
using Nancy.TinyIoc;
using Nancy.Configuration;

namespace cmas.backend
{
    /// <summary>
    /// http://www.paddo.org/microservices-on-net-core-with-nancy-part-1/
    /// Bootstrapper.cs - a place to copy dependencies. At the time of writing this is how you need to copy dependencies into Nancy with .net core. 
    /// I expect this to improve in future. Note we're also enabling tracing so we can see and diagnose any errors when testing the microservice.
    /// </summary>
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        readonly IServiceProvider _serviceProvider;

        public Bootstrapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(true, true);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(_serviceProvider.GetService<ILoggerFactory>());
        }
    }
}