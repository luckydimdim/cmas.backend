using System.Collections.Generic;
using System.Linq;
using cmas.backend.Authentication;
using cmas.backend.Contract;
using cmas.backend.Currency;
using cmas.backend.Unit;
using Nancy;

namespace cmas.backend
{
    public class GeneralModule : NancyModule
    {
        protected List<UserRole> AvailableRoles;
        protected List<UserModel> Users;
        protected List<CurrencyModel> Currencies;
        protected List<UnitModel> Units;
        protected List<ContractModel> Contracts;

        public GeneralModule()
        {
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
                .WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));

            MockCurrency();
            MockUnits();
            MockAvailableRoles();
            MockUsers();
            MockContracts();
        }

        #region mock functions

        private void MockAvailableRoles()
        {
            AvailableRoles = new List<UserRole>();

            int idCounter = 0;


            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    1
                Description = "Старший менеджер"
            });


            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    2
                Description = "Менеджер"
            });


            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    3
                Description = "Руководитель"
            });

            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    4
                Description = "Подрядчик"
            });
        }

        private void MockUsers()
        {
            Users = new List<UserModel>();
            int idCounter = 0;


            // Старший менеджер
            {
                var seniorManager = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "Senior",
                    LastName = "Manager",
                    Login = "SeniorManager",
                    Password = "111"
                };

                seniorManager.UserRole.Add((from r in AvailableRoles where r.Id == 1 select r)
                    .Single());

                Users.Add(seniorManager);
            }


            // Менеджер
            {
                var generalManager = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "",
                    LastName = "Manager",
                    Login = "GeneralManager",
                    Password = "111"
                };

                generalManager.UserRole.Add((from r in AvailableRoles where r.Id == 2 select r)
                    .Single());

                Users.Add(generalManager);
            }


            // Руководитель
            {
                var сhief = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "",
                    LastName = "Сhief",
                    Login = "Сhief",
                    Password = "111"
                };

                сhief.UserRole.Add((from r in AvailableRoles where r.Id == 3 select r)
                    .Single());

                Users.Add(сhief);
            }

            // Подрядчик
            {
                var contractor = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "",
                    LastName = "Contractor",
                    Login = "Contractor",
                    Password = "111"
                };

                contractor.UserRole.Add((from r in AvailableRoles where r.Id == 4 select r)
                    .Single());

                Users.Add(contractor);
            }
        }

        private void MockCurrency()
        {
            Currencies = new List<CurrencyModel>();
            int idCounter = 0;

            Currencies.Add(new CurrencyModel
            {
                Id = ++idCounter, // 1
                Code = "RUR",
                Name = "Рубль",
                ShortName = "руб."
            });

            Currencies.Add(new CurrencyModel
            {
                Id = ++idCounter, // 2
                Code = "USD",
                Name = "Доллар",
                ShortName = "дол."
            });


            Currencies.Add(new CurrencyModel
            {
                Id = ++idCounter, // 3
                Code = "EUR",
                Name = "Евро",
                ShortName = "Евр."
            });

            Currencies.Add(new CurrencyModel
            {
                Id = ++idCounter, // 4
                Code = "JPY",
                Name = "Йена",
                ShortName = "Йен."
            });
        }

        private void MockUnits()
        {
            Units = new List<UnitModel>();

            int idCounter = 0;

            Units.Add(new UnitModel
            {
                Id = +idCounter, // 1
                NameRus = "комплект",
                NameEng = "комплект",
                ShortNameRus = "компл.",
                ShortNameEng = "компл.",
            });

            Units.Add(new UnitModel
            {
                Id = +idCounter, // 2
                NameRus = "штук",
                NameEng = "штук",
                ShortNameRus = "шт.",
                ShortNameEng = "шт.",
            });

            Units.Add(new UnitModel
            {
                Id = +idCounter, // 3
                NameRus = "метр",
                NameEng = "метр",
                ShortNameRus = "м.",
                ShortNameEng = "м.",
            });

            Units.Add(new UnitModel
            {
                Id = +idCounter, // 4
                NameRus = "километр",
                NameEng = "километр",
                ShortNameRus = "км.",
                ShortNameEng = "км.",
            });
        }

        private void MockContracts()
        {
            Contracts = new List<ContractModel>();
            int idCounter = 0;


            #region 155/15-ЯСПГ Строительство жилого дома
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 1
                    Name = "Строительство жилого дома",
                    Number = "155/15-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 403/25-ЯСПГ Строительство электросетей
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 2
                    Name = "Строительство электросетей",
                    Number = "403/25-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 10/389-ЯСПГ Строительство трубопровода
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 3
                    Name = "Строительство трубопровода",
                    Number = "10/389-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 985/22-ЯСПГ Строительство газопровода
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 4
                    Name = "Строительство газопровода",
                    Number = "985/22-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion


            #region 119/55-ЯСПГ Строительство подсобных помещений
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 5
                    Name = "Строительство подсобных помещений",
                    Number = "119/55-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 69/20-ЯСПГ Налоговое консультирование
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 6
                    Name = "Налоговое консультирование",
                    Number = "69/20-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 110/91-ЯСПГ Бухгалтерское консультирование
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 7
                    Name = "Бухгалтерское консультирование",
                    Number = "110/91-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 97/445-ЯСПГ Возведение ограждений
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 8
                    Name = "Возведение ограждений",
                    Number = "97/445-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 232/40-ЯСПГ Закладка фундамента
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 9
                    Name = "Закладка фундамента",
                    Number = "232/40-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion

            #region 90/877-ЯСПГ Транспортировка щебня
            {
                var contract = new ContractModel
                {
                    Id = ++idCounter,                    // 10
                    Name = "Транспортировка щебня",
                    Number = "90/877-ЯСПГ",
                };

                Contracts.Add(contract);
            }
            #endregion
        }

        #endregion
    }
}