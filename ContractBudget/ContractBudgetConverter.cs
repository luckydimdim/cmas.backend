using System.Collections.Generic;
using System.Dynamic;
using cmas.backend.ContractBudget.Models.Item;

namespace cmas.backend.ContractBudget
{
    public class ContractBudgetConverter
    {
        public static List<object> ContractBudgetItemsToJson(List<ContractBudgetAbstractItemModel> items)
        {
            var result = new List<object>();

            foreach (var item in items)
            {
                dynamic row = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)row;

                row.Code = item.Work.Code;
                row.recid = item.Id;
                row.Name = item.Work.NameRus;
                dictionary.Add("01_2017", "1 000");

                if (item is ContractBudgetStageItemModel)
                {
                    var w2ui = new { children = ContractBudgetItemsToJson(item.Childrens)};
                    dictionary.Add("w2ui", w2ui);
                }

                result.Add(row);

            }

            return result;
        }
    }
}