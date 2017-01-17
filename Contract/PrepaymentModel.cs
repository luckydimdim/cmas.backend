using cmas.backend.Currency;
using System;

namespace cmas.backend.Contract
{
    public class PrepaymentModel
    {
        public int Id;

        public string Name;

        public CurrencyModel Currency;

        /// <summary>
        /// Процент
        /// </summary>
        public int Percent;

        /// <summary>
        /// Сумма
        /// </summary>
        public int Value;

        /// <summary>
        /// Дата аванса
        /// </summary>
        public DateTime PaymentDate;
    }
}