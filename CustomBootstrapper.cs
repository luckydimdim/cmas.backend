using Microsoft.Extensions.Options;
using Nancy;
using Nancy.TinyIoc;

namespace cmas.backend
{
    public class CustomBootstrapper: DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<Repository>().AsSingleton();
        }
    }
}