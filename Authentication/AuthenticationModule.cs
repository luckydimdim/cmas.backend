using Nancy;
namespace cmas.backend.Authentication
{
    public class AuthenticationModule : NancyModule
    {
        public AuthenticationModule()
        {
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
                .WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));

            Post("/api/authentication/login", args =>
            {

                return this.Response.AsJson(new
                {
                    id = 1,
                    username = "Andrey.Kuzmenko",
                    firstName = "Andrey",
                    lastName = "Kuzmenko",
                    token = "fake-jwt-token"
                });


            });
        }
    }
}



