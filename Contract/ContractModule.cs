using System.Linq;
using Nancy;

namespace cmas.backend.Contract
{
    public class ContractModule: GeneralModule
    {
        public ContractModule()
        {

            Get("/api/contract/", args =>
            {
                var contracts = (from c in Contracts select c);

                return Response.AsJson(contracts);

            });
        }
    }
}