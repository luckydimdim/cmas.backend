using System;
using System.Collections.Generic;
using cmas.backend.Contract;

namespace cmas.backend.Request
{
    public class RequestModel
    {
        public int Id;

        /// <summary>
        /// Договор
        /// </summary>
        public ContractModel Contract;

        /// <summary>
        /// Период - с
        /// </summary>
        public DateTime FromDate;

        /// <summary>
        /// Период - по
        /// </summary>
        public DateTime ToDate;

        /// <summary>
        /// Выбранные работы
        /// </summary>
        public List<AbstractWorkModel> Works;


        public RequestModel()
        {
            Works = new List<AbstractWorkModel>();
        }
    }
}