using System;
using cmas.backend.ConstructionObject;
using cmas.backend.Currency;
using cmas.backend.Unit;

namespace cmas.backend.Contract.Models.Material
{
    public class MaterialModel : AbstractMaterialModel
    {
        /// <summary>
        /// Дата начала работ
        /// </summary>
        public DateTime DeliveryDate;

        /// <summary>
        /// Стоимость
        /// </summary>
        public override decimal Cost { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public UnitModel Unit;

        /// <summary>
        /// Количество
        /// </summary>
        public int Amount;

        /// <summary>
        /// Объект строительства
        /// </summary>
        public ConstructionObjectModel ObjectConstruction;

        /// <summary>
        /// Валюта
        /// </summary>
        public CurrencyModel Currency;
    }
}