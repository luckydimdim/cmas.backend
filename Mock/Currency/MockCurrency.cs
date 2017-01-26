using System.Collections.Generic;
using cmas.backend.Currency;

namespace cmas.backend.Mock.Currency
{
    public class MockCurrency
    {
        public static List<CurrencyModel> Generate()
        {
            var Currencies = new List<CurrencyModel>();
            
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

            return Currencies;
        }
    }
}