using System;
using System.Collections.Generic;
using cmas.backend.Contract;
using System.Linq;
using cmas.backend.ConstructionObject;
using cmas.backend.Contract.Models;
using cmas.backend.Contract.Models.Material;
using cmas.backend.Contract.Models.Work;
using cmas.backend.Contractor;
using cmas.backend.Currency;
using cmas.backend.Unit;

namespace cmas.backend.Mock.Contracts
{
    public class MockContracts
    {
        public static List<ContractModel> Generate(List<ContractorModel> Contractors, List<ConstructionObjectModel> ConstructionObjects, List<UnitModel> Units, List<CurrencyModel> Currencies)
        {
            var Contracts = new List<ContractModel>();
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

                MockWorksForContract(contract, Contractors, ConstructionObjects, Units, Currencies);
                MockMaterialsForContract(contract, Contractors, ConstructionObjects, Units, Currencies);

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

            return Contracts;
        }

        private static void MockWorksForContract(ContractModel contract, List<ContractorModel> Contractors, List<ConstructionObjectModel> ConstructionObjects, List<UnitModel> Units, List<CurrencyModel> Currencies)
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






            // 001.Подготовительный этап
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "006",
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
                    Code = "007",
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
                    Code = "008",
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
                    Code = "009",
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
                    Code = "010",
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
                    Code = "011",
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



            // 001.Подготовительный этап
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "012",
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
                    Code = "013",
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
                    Code = "014",
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
                    Code = "015",
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
                    Code = "016",
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
                    Code = "017",
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

        private static void MockMaterialsForContract(ContractModel contract, List<ContractorModel> Contractors, List<ConstructionObjectModel> ConstructionObjects, List<UnitModel> Units, List<CurrencyModel> Currencies)
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





            // 001.Стены
            {

                var stage = new MaterialStageModel
                {
                    Id = ++idCounter,
                    Code = "003",
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
                    Code = "004",
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




            // 001.Стены
            {

                var stage = new MaterialStageModel
                {
                    Id = ++idCounter,
                    Code = "005",
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
                    Code = "006",
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



            // 001.Стены
            {

                var stage = new MaterialStageModel
                {
                    Id = ++idCounter,
                    Code = "007",
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
                    Code = "008",
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


            // 001.Стены
            {

                var stage = new MaterialStageModel
                {
                    Id = ++idCounter,
                    Code = "009",
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
                    Code = "010",
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

    }
}