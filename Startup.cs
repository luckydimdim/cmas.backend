using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;

namespace cmas.backend
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy(new NancyOptions
            {
                Bootstrapper = new CustomBootstrapper()
            }));
        }

    }
}