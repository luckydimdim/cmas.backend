using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;
using NLog.Web;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Cmas.Backend.Infrastructure.Domain.Commands;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Linq;
using Cmas.Backend.Infrastructure.Domain.Queries;

namespace cmas.backend
{
    public class Startup
    {
        private ILogger _logger;

        public Startup(IHostingEnvironment env)
        {
            env.ConfigureNLog("nlog.config");
        }

        public static IEnumerable<Assembly> GetReferencingAssemblies(string assemblyName)
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateLibrary(library, assemblyName))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }
            return assemblies;
        }

        private static bool IsCandidateLibrary(RuntimeLibrary library, string assemblyName)
        {
            return library.Name == (assemblyName)
                || library.Dependencies.Any(d => d.Name.StartsWith(assemblyName));
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            var assemblies = GetReferencingAssemblies("Cmas");

            foreach (var assembly in assemblies)
            {
                var t = assembly.DefinedTypes;

                builder
                 .RegisterAssemblyTypes(assembly)
                 .AsClosedTypesOf(typeof(ICommand<>));

                builder
                 .RegisterAssemblyTypes(assembly)
                 .AsClosedTypesOf(typeof(IQuery<,>));
            }



            builder.RegisterType<CommandBuilder>().As<ICommandBuilder>();
            builder.RegisterType<QueryBuilder>().As<IQueryBuilder>();
            builder.RegisterType<QueryFactory>().As<IQueryFactory>();

            builder.RegisterGeneric(typeof(QueryFor<>)).As(typeof(IQueryFor<>));
  
            builder.Register<Func<Type, object>>(c =>
            {
                var componentContext = c.Resolve<IComponentContext>();
                return (t) => {
                    return componentContext.Resolve(t);
                };
            });


            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();
            builder.Populate(services);

            var container = builder.Build();
            
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            env.EnvironmentName = "Production";    // TODO: настроить конфигурацию и использование EnvironmentName.Production;

            loggerFactory.AddNLog();
            app.AddNLogWeb();
            
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/error");  // TODO: Настроить страницу, на которую надо кидать в случае 500х ошибок

            app.UseOwin(x => x.UseNancy(options =>
            {
                options.Bootstrapper = new Bootstrapper(app.ApplicationServices);
            }));

            _logger = loggerFactory.CreateLogger<Startup>();

            applicationLifetime.ApplicationStarted.Register(ApplicationStarted);
            applicationLifetime.ApplicationStopping.Register(ApplicationStopping);
            applicationLifetime.ApplicationStopped.Register(ApplicationStopped);

        }

        /// <summary>
        /// Triggered when the application host has fully started and is about to wait for a graceful shutdown.
        /// </summary>
        /// <param name="logger"></param>
        protected void ApplicationStarted()
        {
            _logger.LogInformation("ApplicationStarted");
        }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown. Requests may still be in flight. Shutdown will block until this event completes.
        /// </summary>
        /// <param name="logger"></param>
        protected void ApplicationStopping()
        {
            _logger.LogInformation("ApplicationStopping");
        }

        /// <summary>
        /// riggered when the application host is performing a graceful shutdown. All requests should be complete at this point. Shutdown will block until this event completes.
        /// </summary>
        /// <param name="logger"></param>
        protected void ApplicationStopped()
        {
            _logger.LogInformation("ApplicationStopped");
        }
    }
}
