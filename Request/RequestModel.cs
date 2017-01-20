using System;
using cmas.backend.Contract;
using cmas.backend.Contractor;

namespace cmas.backend.Request
{
    public class RequestModel
    {
        public int Id;

        /// <summary>
        /// Договор
        /// </summary>
        /*public ContractModel Contract;*/

        /// <summary>
        /// Период - с
        /// </summary>
        /*public DateTime FromDate;*/

        /// <summary>
        /// Период - по
        /// </summary>
        /*public DateTime ToDate;*/

        /// <summary>
        /// Выбранные работы
        /// </summary>
        /*public List<AbstractWorkModel> Works;*/


        /*public RequestModel()
        {
            Works = new List<AbstractWorkModel>();
        }*/

        /// <summary>
        /// Подрядчик
        /// </summary>
        public string ContractorName;

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate;

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime CorrectionDate;

        /// <summary>
        /// Номер договора
        /// </summary>
        public string ContractNumber;

        /// <summary>
        /// Сумма к оплате
        /// </summary>
        public decimal Amount;

        /// <summary>
        /// Статус
        /// </summary>
        public string Status;
    }
}