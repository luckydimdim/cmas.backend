namespace cmas.backend
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "Hello from cmas.backend component!");
        }
    }
}
