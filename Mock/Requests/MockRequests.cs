using System;
using System.Collections.Generic;
using cmas.backend.Request;

namespace cmas.backend.Mock.Requests
{
    public class MockRequests
    {
        public static List<RequestModel> Generate()
        {
            var Requests = new List<RequestModel>();

            Requests.Add(new RequestModel
            {
                Id = 633441,
                ContractorName = "Строительство морского порта",
                CreationDate = new DateTime(2017, 01, 01),
                CorrectionDate = new DateTime(2017, 01, 20),
                ContractNumber = "403/25-ЯСПГ (доп. 2)",
                Amount = 300000000,
                Status = "Черновик"
            });

            Requests.Add(new RequestModel
            {
                Id = 64312,
                ContractorName = "Строительство электросетей",
                CreationDate = new DateTime(2017, 01, 01),
                CorrectionDate = new DateTime(2017, 01, 10),
                ContractNumber = "403/25-ЯСПГ",
                Amount = 1000,
                Status = "На доработку"
            });

            Requests.Add(new RequestModel
            {
                Id = 323552,
                ContractorName = "Строительство электросетей",
                CreationDate = new DateTime(2016, 12, 12),
                CorrectionDate = new DateTime(2015, 05, 17),
                ContractNumber = "7603/2445-ЯСПГ 1795123 (доп. 123)",
                Amount = 45600000,
                Status = "Согласована"
            });

            Requests.Add(new RequestModel
            {
                Id = 45266,
                ContractorName = "Строительство электросетей",
                CreationDate = new DateTime(2017,01,01),
                CorrectionDate = new DateTime(2017,01,10),
                ContractNumber = "403/25-ЯСПГ",
                Amount = 1000,
                Status = "На доработку"
            });

            return Requests;

        }
    }
}