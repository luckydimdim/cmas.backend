using System.Collections.Generic;
using System.Dynamic;
using cmas.backend.Contract.Models.Material;
using cmas.backend.Contract.Models.Work;

namespace cmas.backend.Contract
{
    public class ContractConverter
    {
        public static List<object> ContractMaterialsToJson(List<AbstractMaterialModel> Materials)
        {
            var result = new List<object>();

            foreach (var material in Materials)
            {
                dynamic row = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)row;

                row.Code = material.Code;
                row.recid = material.Id;
                row.Name = material.NameRus;
                row.Cost = material.Cost;

                if (material is MaterialModel)
                {
                    row.Unit = (material as MaterialModel).Unit.NameRus;
                    row.Amount = (material as MaterialModel).Amount;
                    row.Currency = (material as MaterialModel).Currency.Code;
                    row.ObjectConstruction = (material as MaterialModel).ObjectConstruction.Name;

                    row.DeliveryDate = (material as MaterialModel).DeliveryDate.ToString("d");
                }


                if (material is MaterialStageModel)
                {
					dictionary.Add("children", ContractMaterialsToJson(material.Childrens));
                }

                result.Add(row);

            }

            return result;
        }


        public static List<object> ContractWorksToJson(List<AbstractWorkModel> works)
        {
            var result = new List<object>();

            foreach (var work in works)
            {
                dynamic row = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)row;

                row.Code = work.Code;
                row.recid = work.Id;
                row.Name = work.NameRus;
                row.Cost = work.Cost;

                if (work is WorkModel)
                {
                    row.Unit = (work as WorkModel).Unit.NameRus;
                    row.Amount = (work as WorkModel).Amount;
                    row.Currency = (work as WorkModel).Currency.Code;
                    row.ObjectConstruction = (work as WorkModel).ObjectConstruction.Name;

                    row.BeginDate = (work as WorkModel).BeginDate.ToString("d");
                    row.EndDate = (work as WorkModel).EndDate.ToString("d");
                    row.ContractorName = (work as WorkModel).Contractor.Name;

                }


                if (work is WorkStageModel)
                {
                    dictionary.Add("children", ContractWorksToJson(work.Childrens));
                }

                result.Add(row);

            }

            return result;
        }


    }
}