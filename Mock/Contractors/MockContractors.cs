using System.Collections.Generic;
using cmas.backend.Contractor;

namespace cmas.backend.Mock.Contractors
{
    public class MockContractors
    {
        public static List<ContractorModel> Generate()
        {
            var Contractors = new List<ContractorModel>();
            int idCounter = 0;

            Contractors.Add(new ContractorModel
            {
                Id = ++idCounter,
                Name = "ООО Стройиндустрия",
            });

            Contractors.Add(new ContractorModel
            {
                Id = ++idCounter,
                Name = "ЗАО Юниж-Строй",
            });

            Contractors.Add(new ContractorModel
            {
                Id = ++idCounter,
                Name = "ООО Союзспецстрой",
            });

            Contractors.Add(new ContractorModel
            {
                Id = ++idCounter,
                Name = "ООО Городок",
            });

            Contractors.Add(new ContractorModel
            {
                Id = ++idCounter,
                Name = "ООО Строительная комплектация",
            });

            return Contractors;
        }
    }
}