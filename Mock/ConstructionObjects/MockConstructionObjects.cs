using System.Collections.Generic;
using cmas.backend.ConstructionObject;

namespace cmas.backend.Mock.ConstructionObjects
{
    public class MockConstructionObjects
    {
        public static List<ConstructionObjectModel> Generate()
        {
           var ConstructionObjects = new List<ConstructionObjectModel>();
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

            return ConstructionObjects;

        }
    }
}