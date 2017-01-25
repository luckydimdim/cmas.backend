using System.Collections.Generic;

namespace cmas.backend.Contract.Material
{
    public abstract class AbstractMaterialModel
    {
        public int Id;

        public string Code;


        public string NameRus;

        public string NameEng;

        public List<AbstractMaterialModel> Childrens;

        public abstract decimal Cost { get; set; }

        protected AbstractMaterialModel()
        {
            Childrens = new List<AbstractMaterialModel>();
        }
    }
}