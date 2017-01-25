using System;
using System.Collections.Generic;
using cmas.backend.ConstructionObject;
using cmas.backend.Contract.Material;
using cmas.backend.Contractor;

namespace cmas.backend.Contract
{
    /// <summary>
    /// Договор
    /// </summary>
    public class ContractModel
    {
        /// <summary>
        /// Внутренний ID
        /// </summary>
        public int Id;

        /// <summary>
        /// Номер договора
        /// </summary>
        public string Number;

        /// <summary>
        /// Наименование договора
        /// </summary>
        public string Name;

        /// <summary>
        /// Подрядчик
        /// </summary>
        public ContractorModel Contractor;

        /// <summary>
        /// Объекты строительства
        /// </summary>
        public List<ConstructionObjectModel> ConstructionObjects;

        /// <summary>
        /// Дата заключения
        /// </summary>
        public DateTime ConclusionDate;

        /// <summary>
        /// Статус договора
        /// </summary>
        public object ContractState;

        /// <summary>
        /// Вид договора (СМР, МТР, Прочее)
        /// </summary>
        public object ContractView;

        /// <summary>
        /// Тип договора (Стоимостной, Рамочный)
        /// </summary>
        public object ContractType;

        /// <summary>
        /// Авансы
        /// </summary>
        public List<PrepaymentModel> Prepayments;

        /// <summary>
        /// Резерв
        /// </summary>
        public object Reserve;

        /// <summary>
        /// Дата возврата резерва
        /// </summary>
        public DateTime ReserveReturnDate;

        /// <summary>
        /// Доступные работы по договору (запланированные)
        /// </summary>
        public List<AbstractWorkModel> Works;

        /// <summary>
        /// Материалы
        /// </summary>
        public List<AbstractMaterialModel> Materials;

        public ContractModel()
        {
            ConstructionObjects = new List<ConstructionObjectModel>();
            Prepayments = new List<PrepaymentModel>();
            Works = new List<AbstractWorkModel>();
            Materials = new List<AbstractMaterialModel>();
        }
    }
}