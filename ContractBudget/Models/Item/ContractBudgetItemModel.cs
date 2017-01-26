﻿using System.Collections.Generic;

namespace cmas.backend.ContractBudget.Models.Item
{
    public class ContractBudgetItemModel : ContractBudgetAbstractItemModel
    {
        public override List<PaymentModel> Payments { get; set; }

        public ContractBudgetItemModel()
        {
            Payments = new List<PaymentModel>();
        }
    }
}