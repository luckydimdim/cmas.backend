using Nancy;

namespace cmas.backend
{

    /// <summary>
    ///
    /// </summary>
    public class GeneralModule : NancyModule
    {
        protected Repository Repository;

        private void Init(Repository repository)
        {
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
                .WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));

            this.Repository = repository;


            // 001.Подготовительный этап
            {

                var stage = new WorkStageModel
                {
                    Id = ++idCounter,
                    Code = "007",
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
                    Code = "008",
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
                    Code = "009",
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
                    Code = "010",
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
                    Code = "011",
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
                    Code = "012",
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
        }

        public GeneralModule(Repository repository, string modulePath) : base(modulePath)
        {
            Init(repository);
        }

        public GeneralModule(Repository repository)
        {
            Init(repository);
        }

    }
}