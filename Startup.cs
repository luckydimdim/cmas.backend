using Microsoft.AspNetCore.Builder;
using Nancy.Owin;
using Microsoft​.AspNetCore​.Hosting;
using NLog.Web;
using Microsoft​.Extensions​.DependencyInjection;
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


        /// <summary>
        /// FIXME: Добавляемые здесь сервисы необходимо  дублировать в Bootstrapper.cs :(
        /// Возможно позже допилят интеграцию MS DI NanacyFX DI (TinyIo)
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.EnvironmentName = "Production";    // FIXME: настроить конфигурацию и использование EnvironmentName.Production;

            loggerFactory.AddNLog();
            app.AddNLogWeb();

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");  // FIXME: Настроить страницу, на которую надо кидать в случае 500х ошибок
            }


            app.UseOwin(pipeline => pipeline.UseNancy(options =>
            {
                options.Bootstrapper = new Bootstrapper(app.ApplicationServices);
            }));


        }
    }
}
