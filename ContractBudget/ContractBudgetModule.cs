using System.Collections.Generic;
using Nancy;
using System.Linq;


namespace cmas.backend.ContractBudget
{
    public sealed class ContractBudgetModule: GeneralModule
    {


        public ContractBudgetModule(Repository repository) : base(repository, "/api/contractBudget")
        {

            Get("/list", args =>
            {
                var contractBudgets = (from b in Repository.ContractBudgets select b);

                return Response.AsJson(contractBudgets);

            });

            Get("/{id}", args =>
            {
                var contractId = args.id;

                var contractBudget = (from b in Repository.ContractBudgets where b.ContractId == contractId select b).SingleOrDefault();

                if (contractBudget == null)
                    return HttpStatusCode.NotFound;;

                return HttpStatusCode.OK;

            });

            Get("/{id}/days", args =>
            {
                var contractId = args.id;

                var contractBudget = (from b in Repository.ContractBudgets where b.ContractId == contractId select b).SingleOrDefault();

                return Response.AsJson(contractBudget);

            });

            Get("/{id}/months", args =>
            {
                var contractId = args.id;

                var contractBudget = (from b in Repository.ContractBudgets where b.ContractId == contractId select b).SingleOrDefault();

                if (contractBudget == null)
                    return Response.AsJson(new List<object>());

                var result = ContractBudgetConverter.ContractBudgetItemsToJson(contractBudget.Items);

                var response = (Response)Newtonsoft.Json.JsonConvert.SerializeObject(result);
                response.ContentType = "application/json";
                return response;

            });

            Post("/{id}/create", args =>
            {
                var contractId = args.id;

                var contractBudget = ContractBudgetLogic.CreateContractBudget(contractId, ref Repository.ContractBudgets,Repository.Contracts);

                if (contractBudget == null)
                    return HttpStatusCode.BadRequest;

                return HttpStatusCode.OK;

            });



        }
    }
}