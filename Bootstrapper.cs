using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

namespace cmas.backend
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        private readonly IServiceProvider _serviceProvider = null;

        public Bootstrapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            // Perform registration that should have an application lifetime
        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
        }

        protected override ILifetimeScope GetApplicationContainer()
        {
            return _serviceProvider.GetService<ILifetimeScope>();
        }
    }
}