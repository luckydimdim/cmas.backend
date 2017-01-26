using System.Linq;
using Nancy;

namespace cmas.backend.Contract
{
    public sealed class ContractModule: GeneralModule
    {


        public ContractModule(Repository repository) : base(repository, "/api/contract")
        {

            Get("/", args =>
            {
                var contracts = (from c in Repository.Contracts select c);

                return Response.AsJson(contracts);

            });

            Get("/{id}/materials", args =>
            {
                var contractId = args.id;

                var contract = (from c in Repository.Contracts where c.Id == contractId select c).SingleOrDefault();

                var result = ContractConverter.ContractMaterialsToJson(contract.Materials);


                var response = (Response)Newtonsoft.Json.JsonConvert.SerializeObject(result);
                response.ContentType = "application/json";
                return response;

            });

            Get("/{id}/works", args =>
            {
                var contractId = args.id;

                var contract = (from c in Repository.Contracts where c.Id == contractId select c).SingleOrDefault();

                var result = ContractConverter.ContractWorksToJson(contract.Works);

                var response = (Response)Newtonsoft.Json.JsonConvert.SerializeObject(result);
                response.ContentType = "application/json";
                return response;

            });

        }
    }
}