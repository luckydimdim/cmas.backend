using System.Collections.Generic;
using cmas.backend.Contract;

namespace cmas.backend.ContractBudget.Item
{
    public abstract class ContractBudgetAbstractItemModel
    {
        public int Id;
        public int WorkId;

        public abstract List<PaymentModel> Payments { get; set; }

        public List<ContractBudgetAbstractItemModel> Childrens { get; set; }

        public ContractBudgetAbstractItemModel()
        {
            Childrens = new List<ContractBudgetAbstractItemModel>();
        }

    }
}