using System.Collections.Generic;
using cmas.backend.Contract.Models.Work;

namespace cmas.backend.ContractBudget.Models.Item
{
    public abstract class ContractBudgetAbstractItemModel
    {
        public int Id;
        public AbstractWorkModel Work;

        public abstract List<PaymentModel> Payments { get; set; }

        public List<ContractBudgetAbstractItemModel> Childrens { get; set; }

        protected ContractBudgetAbstractItemModel()
        {
            Childrens = new List<ContractBudgetAbstractItemModel>();
        }

    }
}