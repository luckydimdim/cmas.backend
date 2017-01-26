using System.Linq;
using Nancy;
using Nancy.Cryptography;

namespace cmas.backend.Authentication
{
    public class AuthenticationModule : GeneralModule
    {

        public AuthenticationModule(Repository repository) : base(repository)
        {

            Post("/api/authentication/login", args =>
            {
                var login = this.Request.Form["login"].Value;
                var password = this.Request.Form["password"].Value;

                var user = (from u in Repository.Users where u.Login == login && u.Password == password select u).SingleOrDefault();

                if (user != null)
                    return Response.AsJson(user);

                return HttpStatusCode.Forbidden;
            });
        }


    }
}


