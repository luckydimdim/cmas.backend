using System.Collections.Generic;
using cmas.backend.ContractBudget.Item;

namespace cmas.backend.ContractBudget
{
    public class ContractBudgetModel
    {
        /// <summary>
        /// Внутренний ID
        /// </summary>
        public int Id;


        /// <summary>
        /// ID договора
        /// </summary>
        public int contractId;

        /// <summary>
        /// Доступные работы по договору (запланированные)
        /// </summary>
        public List<ContractBudgetAbstractItemModel> Items;

        public ContractBudgetModel()
        {
            Items = new List<ContractBudgetAbstractItemModel>();
        }

    }
}