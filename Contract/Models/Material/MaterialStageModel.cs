﻿using System.Linq;

namespace cmas.backend.Contract.Models.Material
{
    public class MaterialStageModel : AbstractMaterialModel
    {
        public override decimal Cost
        {
            get { return (from c in Childrens select c.Cost).Sum(); }

            set { }
        }



    }
}