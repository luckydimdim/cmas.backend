using System;
using System.Collections.Generic;
using System.Dynamic;
using Nancy;
using System.Linq;
using cmas.backend.Contract;
using cmas.backend.ContractBudget.Item;


namespace cmas.backend.ContractBudget
{
    public class ContractBudgetModule: GeneralModule
    {
        private List<ContractBudgetAbstractItemModel> ConvertFromWork( ref int idCounter, List<AbstractWorkModel> works)
        {
            List<ContractBudgetAbstractItemModel> result = new List<ContractBudgetAbstractItemModel>();

            foreach (var work in works)
            {
                ContractBudgetAbstractItemModel item = null;

                if (work is WorkModelStage)
                    item = new ContractBudgetStageItemModel();
                else
                    item = new ContractBudgetItemModel();

                item.Id = ++idCounter;
                item.WorkId = work.Id;

                if (item is ContractBudgetItemModel)
                {

                    var payment = new PaymentModel
                    {
                        Cost = work.Cost
                    };

                    var wModel = work as WorkModel;
                    if (wModel != null)
                    {
                        payment.PaymentDate = wModel.EndDate;
                    }

                    item.Payments.Add(payment);
                }

            if (work is WorkModelStage)
                    item.Childrens = ConvertFromWork(ref idCounter, work.Childrens);

                result.Add(item);
            }

            return result;
        }

        private List<object> ConvertFromContractBudgetAbstractItemModel(List<AbstractWorkModel> Works, List<ContractBudgetAbstractItemModel> items)
        {
            var result = new List<object>();

            foreach (var item in items)
            {
                dynamic row = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)row;

                var work = (from w in Works where w.Id == item.WorkId select w).SingleOrDefault();

                row.Code = work.Code;
                row.recid = item.Id;
                row.Name = work.NameRus;
                dictionary.Add("01_2017", "1 000");

                if (item is ContractBudgetStageItemModel)
                {
                    var w2ui = new { children = ConvertFromContractBudgetAbstractItemModel(work.Childrens, item.Childrens)};
                    dictionary.Add("w2ui", w2ui);
                }

p            }

            return result;
        }

        private ContractBudgetModel createContractBudget(int contractId)
        {
            var contractBudget = (from b in ContractBudgets where b.contractId == contractId select b).SingleOrDefault();
            var contract = (from b in Contracts where b.Id == contractId select b).SingleOrDefault();
            var count = (from b in ContractBudgets select b).Count();

            if (contractBudget == null)
            {
                int idCounter = 0;
                contractBudget = new ContractBudgetModel();

                contractBudget.Id = count + 1;
                contractBudget.contractId = contractId;

                contractBudget.Items = ConvertFromWork(ref idCounter, contract.Works);

                ContractBudgets.Add(contractBudget);
            }

            return contractBudget;
        }

        public ContractBudgetModule()
        {

            Get("/api/contractBudget/", args =>
            {
                var contractBudgets = (from b in ContractBudgets select b);

                return Response.AsJson(contractBudgets);

            });

            Get("/api/contractBudget/days/{id}", args =>
            {
                var contractId = args.id;

                var contractBudget = (from b in ContractBudgets where b.contractId == contractId select b).SingleOrDefault();

                return Response.AsJson(contractBudget);

            });

            Get("/api/contractBudget/months/{id}", args =>
            {
                var contractId = args.id;

                var contractBudget = (from b in ContractBudgets where b.contractId == contractId select b).SingleOrDefault();

                if (contractBudget == null)
                {
                    contractBudget = createContractBudget(contractId);
                }

                var contract = (from b in Contracts where b.Id == contractId select b).SingleOrDefault();

                var result = ConvertFromContractBudgetAbstractItemModel(contract.Works, contractBudget.Items);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(result);

                return Response.AsText(json);

            });



            Post("/api/contractBudget/create/{id}", args =>
            {
                var contractId = args.id;

                var contractBudget = createContractBudget(contractId);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(contractBudget);

                return Response.AsText(json);

            });



        }
    }
}