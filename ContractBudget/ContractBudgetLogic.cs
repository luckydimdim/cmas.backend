using System.Collections.Generic;
using System.Linq;
using cmas.backend.Contract.Models;
using cmas.backend.Contract.Models.Work;
using cmas.backend.ContractBudget.Models;
using cmas.backend.ContractBudget.Models.Item;

namespace cmas.backend.ContractBudget
{
    public class ContractBudgetLogic
    {
        private static List<ContractBudgetAbstractItemModel> ConvertFromWork( ref int idCounter, List<AbstractWorkModel> works)
        {
            List<ContractBudgetAbstractItemModel> result = new List<ContractBudgetAbstractItemModel>();

            foreach (var work in works)
            {
                ContractBudgetAbstractItemModel item = null;

                if (work is WorkStageModel)
                    item = new ContractBudgetStageItemModel();
                else
                    item = new ContractBudgetItemModel();

                item.Id = ++idCounter;
                item.Work = work;

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

                if (work is WorkStageModel)
                    item.Childrens = ConvertFromWork(ref idCounter, work.Childrens);

                result.Add(item);
            }

            return result;
        }

        public static ContractBudgetModel CreateContractBudget(int contractId, ref List<ContractBudgetModel> ContractBudgets, List<ContractModel> Contracts )
        {
            var contractBudget = (from b in ContractBudgets where b.ContractId == contractId select b).SingleOrDefault();
            var contract = (from b in Contracts where b.Id == contractId select b).SingleOrDefault();
            var count = (from b in ContractBudgets select b).Count();

            if (contract == null)
                return null;

            if (contractBudget == null)
            {
                int idCounter = 0;
                contractBudget = new ContractBudgetModel();

                contractBudget.Id = count + 1;
                contractBudget.ContractId = contractId;

                contractBudget.Items = ConvertFromWork(ref idCounter, contract.Works);

                ContractBudgets.Add(contractBudget);
            }

            return contractBudget;
        }
    }
}