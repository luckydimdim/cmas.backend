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

namespace cmas.backend
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            env.ConfigureNLog("nlog.config");
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();
            builder.Populate(services);

            var container = builder.Build();
            
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
        }
    }
}
