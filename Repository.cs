using System;
using System.Collections.Generic;
using cmas.backend.Authentication;
using cmas.backend.ConstructionObject;
using cmas.backend.Contract.Models;
using cmas.backend.ContractBudget.Models;
using cmas.backend.Contractor;
using cmas.backend.Currency;
using cmas.backend.Mock.ConstructionObjects;
using cmas.backend.Mock.ContractBudgets;
using cmas.backend.Mock.Contractors;
using cmas.backend.Mock.Contracts;
using cmas.backend.Mock.Currency;
using cmas.backend.Mock.Requests;
using cmas.backend.Mock.Roles;
using cmas.backend.Mock.Units;
using cmas.backend.Mock.Users;
using cmas.backend.Request;
using cmas.backend.Unit;

namespace cmas.backend
{
    public class Repository
    {
        public List<UserRole> AvailableRoles;
        public List<UserModel> Users;
        public List<CurrencyModel> Currencies;
        public List<UnitModel> Units;
        public List<ContractModel> Contracts;
        public List<ConstructionObjectModel> ConstructionObjects;
        public List<ContractorModel> Contractors;
        public List<RequestModel> Requests;
        public List<ContractBudgetModel> ContractBudgets;

        public Repository()
        {
            Console.WriteLine("Repository.ctor()");

            Currencies = MockCurrency.Generate();
            Units = MockUnits.Generate();
            AvailableRoles = MockAvailableRoles.Generate();
            Contractors = MockContractors.Generate();
            ConstructionObjects = MockConstructionObjects.Generate();
            Users = MockUsers.Generate(AvailableRoles);
            Contracts = MockContracts.Generate(Contractors, ConstructionObjects, Units, Currencies);
            Requests = MockRequests.Generate();
            ContractBudgets = MockContractBudgets.Generate();
        }
    }


}