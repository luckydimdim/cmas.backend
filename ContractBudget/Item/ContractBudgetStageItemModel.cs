using System.Collections.Generic;
using System.Linq;

namespace cmas.backend.ContractBudget.Item
{
    public class ContractBudgetStageItemModel : ContractBudgetAbstractItemModel
    {
        /// <summary>
        /// Стоимость
        /// </summary>
        public override List<PaymentModel> Payments {
            get { return new List<PaymentModel>(); }

            set
            {
            }}
    }
}