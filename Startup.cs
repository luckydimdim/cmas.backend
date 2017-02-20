namespace cmas.backend
{
    using Microsoft.AspNetCore.Builder;
    using Nancy.Owin;
    using System;

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                /*
                Console.WriteLine(context.Request.Path);
                context.Request.Path = "/contract";
                */
                await next.Invoke();
                
            });

            app.UseOwin(x => x.UseNancy());


        }
    }
}
