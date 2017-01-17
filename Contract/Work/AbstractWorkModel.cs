namespace cmas.backend.Contract
{
    /// <summary>
    /// Абстрактный класс для работ или этапов, под-этапов
    /// </summary>
    public abstract class AbstractWorkModel
    {
        public int Id;

        /// <summary>
        /// Код роботы/Этапа
        /// </summary>
        public string Code;


        /// <summary>
        /// Наименование на русском
        /// </summary>
        public string NameRus;

        /// <summary>
        /// Наименование на англ
        /// </summary>
        public string NameEng;

        /// <summary>
        /// Родительская работа/этап
        /// </summary>
        public AbstractWorkModel Parent;
    }
}