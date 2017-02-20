using Microsoft.AspNetCore.Builder;
using Nancy.Owin;
using Microsoft​.AspNetCore​.Hosting;

namespace cmas.backend
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = "Production";    // FIXME: настроить конфигурацию и использование EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");  // FIXME: Настроить страницу, на которую надо кидать в случае 500х ошибок
            }

            app.UseOwin(x => x.UseNancy());


        }
    }
}
