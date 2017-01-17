namespace cmas.backend.Currency
{
    public class CurrencyModel
    {
        public int Id;

        /// <summary>
        /// Короткое наименование (руб., дол.)
        /// </summary>
        public string ShortName;

        /// <summary>
        /// Наименование (рубль)
        /// </summary>
        public string Name;

        /// <summary>
        /// Код валют (RUR)
        /// </summary>
        public string Code;
    }
}