using System;
using cmas.backend.ConstructionObject;
using cmas.backend.Contractor;
using cmas.backend.Currency;
using cmas.backend.Unit;

namespace cmas.backend.Contract
{
    /// <summary>
    /// Работа (или услуга)
    /// </summary>
    public class WorkModel : AbstractWorkModel
    {
        /// <summary>
        /// Дата начала работ
        /// </summary>
        public DateTime BeginDate;

        /// <summary>
        /// Дата окончания работ
        /// </summary>
        public DateTime EndDate;

        /// <summary>
        /// Единица измерения
        /// </summary>
        public UnitModel Unit;

        /// <summary>
        /// Объем работ
        /// </summary>
        public int Amount;

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Cost;

        /// <summary>
        /// Валюта
        /// </summary>
        public CurrencyModel Currency;

        /// <summary>
        /// Исполнитель (подрядчик)
        /// </summary>
        public ContractorModel Contractor;

        /// <summary>
        /// Объект строительства
        /// </summary>
        public ConstructionObjectModel ObjectConstruction;
    }
}