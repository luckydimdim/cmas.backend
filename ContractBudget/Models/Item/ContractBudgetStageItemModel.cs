using System.Collections.Generic;

namespace cmas.backend.ContractBudget.Models.Item
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