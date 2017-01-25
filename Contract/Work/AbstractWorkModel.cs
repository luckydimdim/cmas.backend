using System.Collections.Generic;

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
        /// Подэтапы/работы
        /// </summary>
        public List<AbstractWorkModel> Childrens;

        public abstract decimal Cost { get; set; }

        protected AbstractWorkModel()
        {
            Childrens = new List<AbstractWorkModel>();
        }
    }
}