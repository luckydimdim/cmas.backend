using System;
using System.Collections.Generic;
using System.Linq;
using cmas.backend.Authentication;
using cmas.backend.ConstructionObject;
using cmas.backend.Contract;
using cmas.backend.Contract.Material;
using cmas.backend.ContractBudget;
using cmas.backend.Contractor;
using cmas.backend.Currency;
using cmas.backend.Request;
using cmas.backend.Unit;
using Nancy;

namespace cmas.backend
{

    /// <summary>
    /// Родительсякий модуль, который инициализирует фейковый репозиторий
    /// </summary>
    public class GeneralModule : NancyModule
    {
        protected List<UserRole> AvailableRoles;
        protected List<UserModel> Users;
        protected List<CurrencyModel> Currencies;
        protected List<UnitModel> Units;
        protected List<ContractModel> Contracts;
        protected List<ConstructionObjectModel> ConstructionObjects;
        protected List<ContractorModel> Contractors;
        protected List<RequestModel> Requests;
        protected List<ContractBudgetModel> ContractBudgets;

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
            MockContractors();
            MockConstructionObjects();
            MockContracts();
            MockRequests();
            MockContractBudgets();
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

        private void MockContractors()
        {
            Contractors = new List<ContractorModel>();
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
                Id = ++idCounter, // 1
                NameRus = "комплект",
                NameEng = "комплект",
                ShortNameRus = "компл.",
                ShortNameEng = "компл.",
            });

            Units.Add(new UnitModel
            {
                Id = ++idCounter, // 2
                NameRus = "штук",
                NameEng = "штук",
                ShortNameRus = "шт.",
                ShortNameEng = "шт.",
            });

            Units.Add(new UnitModel
            {
                Id = ++idCounter, // 3
                NameRus = "метр",
                NameEng = "метр",
                ShortNameRus = "м.",
                ShortNameEng = "м.",
            });

            Units.Add(new UnitModel
            {
                Id = ++idCounter, // 4
                NameRus = "километр",
                NameEng = "километр",
                ShortNameRus = "км.",
                ShortNameEng = "км.",
            });

            Units.Add(new UnitModel
            {
                Id = ++idCounter, // 5
                NameRus = "часы",
                NameEng = "часы",
                ShortNameRus = "ч.",
                ShortNameEng = "ч.",
            });

        }

        private void MockConstructionObjects()
        {
            ConstructionObjects = new List<ConstructionObjectModel>();
            int idCounter = 0;


            ConstructionObjects.Add(new ConstructionObjectModel
            {
                Id = ++idCounter,
                Name = "Жилой дом",
                ShortName = "Жилой дом"
            });

            ConstructionObjects.Add(new ConstructionObjectModel
            {
                Id = ++idCounter,
                Name = "Бойлерная станция",
                ShortName = "Бойлерная станция"
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
                             ConclusionDate = new DateTime(2017,01,01),
                             Contractor = (from c in Contractors where c.Id == 1 select c).SingleOrDefault()
                         };

                         contract.ConstructionObjects.AddRange((from c in ConstructionObjects where (c.Id == 1 || c.Id == 2) select c));

                         MockWorksForContract(contract);
                         MockMaterialsForContract(contract);

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

        private void MockWorksForContract(ContractModel contract)
        {
            /*
                001.Подготовительный этап
                    001.1.Геологическое исследование участка
                    001.2.Архитектурное проектирование
                    001.3.Строительство фундамента
                002.Строительство коробки
                    002.1.Строительство стен
                    002.2.Строительство внутренних перекрытий
                    002.3.Строительство внешних перекрытий
                    002.4.Строительство крыши
                003.Внутренние работы
                    003.1.Инженерные коммуникации в доме
                        003.1.1.Подключение электроснабжения
                        003.1.2.Подключение газоснабжение
                        003.1.3.Подключение отопления
                        003.1.4.Подключение кондиционирования
                    003.2.Утепление и отделка фасадов
                    003.3.Утепление чердачного перекрытия
                004.Отделка
                        004.1.Внутренняя отделка
                        004.2.Внешняя отделка
                005.Ландшафтные работы
                    005.1.Озеленение территории
                    005.2.Благоустройство
                006.Другое
                    006.1.Установка освещения участка и проезда к участку
                    006.2.Настрйока системы видеонаблюдения
            */

            int idCounter = 0;

            var houseObject = (from obj in ConstructionObjects where obj.Id == 1 select obj).SingleOrDefault();
            var hourUnit = (from u in Units where u.Id == 5 select u).SingleOrDefault();
            var rurCurrency = (from c in Currencies where c.Code == "RUR" select c).SingleOrDefault();
            var stroyindustriyaContractor = (from c in Contractors where c.Id == 1 select c).SingleOrDefault();    // ООО Стройиндустрия

            // 001.Подготовительный этап
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "001",
                    NameRus = "Подготовительный этап",
                    NameEng = "Подготовительный этап",
                };

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Геологическое исследование участка",
                    NameEng = "Геологическое исследование участка",
                    BeginDate = new DateTime(2017, 01, 01),
                    EndDate = new DateTime(2017, 01, 03),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Архитектурное проектирование",
                    NameEng = "Архитектурное проектирование",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".3",
                    NameRus = "Строительство фундамента",
                    NameEng = "Строительство фундамента",
                    BeginDate = new DateTime(2017, 01, 09),
                    EndDate = new DateTime(2017, 01, 20),
                    ObjectConstruction = houseObject,
                    Amount = 40,
                    Unit = hourUnit,
                    Cost = 1300,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                contract.Works.Add(stage);
            }

            // 002.Строительство коробки
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "002",
                    NameRus = "Строительство коробки",
                    NameEng = "Строительство коробки",
                };

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Строительство стен",
                    NameEng = "Строительство стен",
                    BeginDate = new DateTime(2017, 01, 01),
                    EndDate = new DateTime(2017, 01, 03),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Строительство внутренних перекрытий",
                    NameEng = "Строительство внутренних перекрытий",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".3",
                    NameRus = "Строительство внешних перекрытий",
                    NameEng = "Строительство внешних перекрытий",
                    BeginDate = new DateTime(2017, 01, 09),
                    EndDate = new DateTime(2017, 01, 20),
                    ObjectConstruction = houseObject,
                    Amount = 40,
                    Unit = hourUnit,
                    Cost = 1300,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });


                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".4",
                    NameRus = "Строительство крыши",
                    NameEng = "Строительство крыши",
                    BeginDate = new DateTime(2017, 01, 09),
                    EndDate = new DateTime(2017, 01, 20),
                    ObjectConstruction = houseObject,
                    Amount = 40,
                    Unit = hourUnit,
                    Cost = 1300,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                contract.Works.Add(stage);
            }

            // 003.Внутренние работы
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "003",
                    NameRus = "Внутренние работы",
                    NameEng = "Внутренние работы",
                };

                var Stage_003_1 = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Инженерные коммуникации в доме",
                    NameEng = "Инженерные коммуникации в доме",
                };

                Stage_003_1.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = Stage_003_1.Code + ".1",
                    NameRus = "Подключение электроснабжения",
                    NameEng = "Подключение электроснабжения",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                Stage_003_1.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = Stage_003_1.Code + ".2",
                    NameRus = "Подключение газоснабжение",
                    NameEng = "Подключение газоснабжение",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                Stage_003_1.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = Stage_003_1.Code + ".3",
                    NameRus = "Подключение отопления",
                    NameEng = "Подключение отопления",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                Stage_003_1.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = Stage_003_1.Code + ".4",
                    NameRus = "Подключение кондиционирования",
                    NameEng = "Подключение кондиционирования",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(Stage_003_1);

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Утепление и отделка фасадов",
                    NameEng = "Утепление и отделка фасадов",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".3",
                    NameRus = "Утепление чердачного перекрытия",
                    NameEng = "Утепление чердачного перекрытия",
                    BeginDate = new DateTime(2017, 01, 09),
                    EndDate = new DateTime(2017, 01, 20),
                    ObjectConstruction = houseObject,
                    Amount = 40,
                    Unit = hourUnit,
                    Cost = 1300,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                contract.Works.Add(stage);
            }

            // 004.Отделка
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "004",
                    NameRus = "Отделка",
                    NameEng = "Отделка",
                };

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Внутренняя отделка",
                    NameEng = "Внутренняя отделка",
                    BeginDate = new DateTime(2017, 01, 01),
                    EndDate = new DateTime(2017, 01, 03),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Внешняя отделка",
                    NameEng = "Внешняя отделка",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                contract.Works.Add(stage);
            }

            // 005.Ландшафтные работы
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "005",
                    NameRus = "Ландшафтные работы",
                    NameEng = "Ландшафтные работы",
                };

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Озеленение территории",
                    NameEng = "Озеленение территории",
                    BeginDate = new DateTime(2017, 01, 01),
                    EndDate = new DateTime(2017, 01, 03),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Благоустройство",
                    NameEng = "Благоустройство",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                contract.Works.Add(stage);
            }

            // 006.Другое
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "006",
                    NameRus = "Другое",
                    NameEng = "Другое",
                };

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Установка освещения участка и проезда к участку",
                    NameEng = "Установка освещения участка и проезда к участку",
                    BeginDate = new DateTime(2017, 01, 01),
                    EndDate = new DateTime(2017, 01, 03),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                stage.Childrens.Add(new WorkModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Настрйока системы видеонаблюдения",
                    NameEng = "Настрйока системы видеонаблюдения",
                    BeginDate = new DateTime(2017, 01, 03),
                    EndDate = new DateTime(2017, 01, 09),
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = hourUnit,
                    Cost = 500,
                    Currency = rurCurrency,
                    Contractor = stroyindustriyaContractor
                });

                contract.Works.Add(stage);
            }

        }


        private void MockMaterialsForContract(ContractModel contract)
        {
            /*
                001.Стены
                    001.1.Кирпич
                    001.2.Пеноблоки
                    001.3.Утеплитель
                002.Общее
                    002.1.Песок
                    002.2.Уголки арочные
                003.Внутренняя отделка
                    003.1.Штукатурка
                        003.1.1.Штукатурка ВОЛМА Холст
                        003.1.2.Штукатурка универсальная
                    003.2.Саморезы
                        003.2.1.Саморезы для тонких пластин Standers, оцинкованные, с буром
                        003.2.2.Саморезы гипсокартон-металл, 3.5х32 мм
                   003.2.Шпаклевка
                        003.2.1.Шпаклёвка мелкозернистая Dulux Maxi
                        003.2.2.Шпаклёвка суперлегкая Semin Sem-Light
                004.Бетоноконтакт
                005.Грунт
                006.Кнауф Ротбанд
                007.Направляющие
                008.Подвесы
                009.Крабы
                010.Соединители
                011.Монтажный клей "Perlfix"
                */

            int idCounter = 0;

            var houseObject = (from obj in ConstructionObjects where obj.Id == 1 select obj).SingleOrDefault();
            var pieceUnit = (from u in Units where u.Id == 2 select u).SingleOrDefault();
            var rurCurrency = (from c in Currencies where c.Code == "RUR" select c).SingleOrDefault();
            var stroyindustriyaContractor = (from c in Contractors where c.Id == 1 select c).SingleOrDefault();    // ООО Стройиндустрия

            // 001.Стены
            {

                var stage = new MaterialStageModel
                {
                    Id = ++idCounter,
                    Code = "001",
                    NameRus = "Стены",
                    NameEng = "Стены",
                };

                stage.Childrens.Add(new MaterialModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Кирпич",
                    NameEng = "Кирпич",
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = pieceUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    DeliveryDate = new DateTime(2017,01,19)
                });

                stage.Childrens.Add(new MaterialModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Пеноблоки",
                    NameEng = "Пеноблоки",
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = pieceUnit,
                    Cost = 1000,
                    DeliveryDate = new DateTime(2017,01,25),
                    Currency = rurCurrency,
                });

                stage.Childrens.Add(new MaterialModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".3",
                    NameRus = "Утеплитель",
                    NameEng = "Утеплитель",
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = pieceUnit,
                    Cost = 1000,
                    DeliveryDate = new DateTime(2017,02,05),
                    Currency = rurCurrency,
                });

                contract.Materials.Add(stage);
            }

            // 002.Общее
            {

                var stage = new MaterialStageModel
                {
                    Id = ++idCounter,
                    Code = "002",
                    NameRus = "Общее",
                    NameEng = "Общее",
                };

                stage.Childrens.Add(new MaterialModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".1",
                    NameRus = "Песок",
                    NameEng = "Песок",
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = pieceUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    DeliveryDate = new DateTime(2017,02,20),
                });

                stage.Childrens.Add(new MaterialModel
                {
                    Id = ++idCounter,
                    Code = stage.Code + ".2",
                    NameRus = "Уголки арочные",
                    NameEng = "Уголки арочные",
                    ObjectConstruction = houseObject,
                    Amount = 16,
                    Unit = pieceUnit,
                    Cost = 1000,
                    Currency = rurCurrency,
                    DeliveryDate = new DateTime(2017,03,01),
                });

                contract.Materials.Add(stage);
            }

        }

        private void MockContractBudgets()
        {
            ContractBudgets = new List<ContractBudgetModel>();
        }

        #endregion

        #region Requests

        private void MockRequests()
        {
            Requests = new List<RequestModel>();

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
        }


        #endregion



    }
}