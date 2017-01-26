using System.Linq;
using Nancy;

namespace cmas.backend.Request
{
    public class RequestModule: GeneralModule
    {
        public RequestModule(Repository repository) : base(repository)
        {
            Get("/api/request/list/", args =>
            {
                var requests = (from r in Repository.Requests select r);

                return Response.AsJson(requests);
            });
        }
    }
}