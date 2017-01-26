using System.Collections.Generic;
using cmas.backend.ContractBudget.Models.Item;

namespace cmas.backend.ContractBudget.Models
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
        public int ContractId;

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