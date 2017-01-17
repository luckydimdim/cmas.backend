using Nancy;

namespace cmas.backend.Contract
{
    public class ContractModule: GeneralModule
    {
        public ContractModule()
        {

            Get("/api/contract/", args =>
            {
                return HttpStatusCode.NotImplemented;
            });
        }
    }
}