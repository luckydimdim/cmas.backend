using System.Linq;
using Nancy;

namespace cmas.backend.Request
{
    public class RequestModule: GeneralModule
    {
        public RequestModule()
        {
            Get("/api/request/list/", args =>
            {
                var requests = (from r in Requests select r);

                return Response.AsJson(requests);
            });
        }
    }
}