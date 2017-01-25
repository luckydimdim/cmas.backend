using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using cmas.backend.Contract.Material;
using cmas.backend.ContractBudget.Item;
using Nancy;

namespace cmas.backend.Contract
{
    public class ContractModule: GeneralModule
    {

        public List<object> ContractMaterialsToJson(List<AbstractMaterialModel> Materials)
        {
            var result = new List<object>();

            foreach (var material in Materials)
            {
                dynamic row = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)row;

                row.Code = material.Code;
                row.recid = material.Id;
                row.Name = material.NameRus;
                row.Cost = material.Cost;

                if (material is MaterialModel)
                {
                    row.Unit = (material as MaterialModel).Unit.NameRus;
                    row.Amount = (material as MaterialModel).Amount;
                    row.Currency = (material as MaterialModel).Currency.Code;
                    row.ObjectConstruction = (material as MaterialModel).ObjectConstruction.Name;

                    row.DeliveryDate = (material as MaterialModel).DeliveryDate.ToString("s");
                }


                if (material is MaterialStageModel)
                {
                    var w2ui = new { children = ContractMaterialsToJson(material.Childrens)};
                    dictionary.Add("w2ui", w2ui);
                }

                result.Add(row);

            }

            return result;
        }


        public List<object> ContractWorksToJson(List<AbstractWorkModel> works)
        {
            var result = new List<object>();

            foreach (var work in works)
            {
                dynamic row = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)row;

                row.Code = work.Code;
                row.recid = work.Id;
                row.Name = work.NameRus;
                row.Cost = work.Cost;

                if (work is WorkModel)
                {
                    row.Unit = (work as WorkModel).Unit.NameRus;
                    row.Amount = (work as WorkModel).Amount;
                    row.Currency = (work as WorkModel).Currency.Code;
                    row.ObjectConstruction = (work as WorkModel).ObjectConstruction.Name;

                    row.BeginDate = (work as WorkModel).BeginDate.ToString("s");
                    row.EndDate = (work as WorkModel).EndDate.ToString("s");
                    row.ContractorName = (work as WorkModel).Contractor.Name;

                }


                if (work is WorkStageModel)
                {
                    var w2ui = new { children = ContractWorksToJson(work.Childrens)};
                    dictionary.Add("w2ui", w2ui);
                }

                result.Add(row);

            }

            return result;
        }


        public ContractModule()
        {

            Get("/api/contract/", args =>
            {
                var contracts = (from c in Contracts select c);

                return Response.AsJson(contracts);

            });

            Get("/api/contract/{id}/materials", args =>
            {
                var contractId = args.id;

                var contract = (from c in Contracts where c.Id == contractId select c).SingleOrDefault();

                var result = ContractMaterialsToJson(contract.Materials);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(result);

                return Response.AsText(json);

            });

            Get("/api/contract/{id}/works", args =>
            {
                var contractId = args.id;

                var contract = (from c in Contracts where c.Id == contractId select c).SingleOrDefault();

                var result = ContractWorksToJson(contract.Works);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(result);

                return Response.AsText(json);

            });

        }
    }
}