using System.Collections.Generic;
using cmas.backend.Unit;

namespace cmas.backend.Mock.Units
{
    public class MockUnits
    {

        public static  List<UnitModel> Generate()
        {
           var  Units = new List<UnitModel>();

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

            return Units;
        }
    }
}