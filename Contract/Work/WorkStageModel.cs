using System.Linq;

namespace cmas.backend.Contract
{
    /// <summary>
    /// ываыв
    /// </summary>
    public class WorkModelStage : AbstractWorkModel
    {
        /// <summary>
        /// Стоимость
        /// </summary>
        public override decimal Cost {
            get { return (from c in Childrens select c.Cost).Sum(); }

            set
            {
            }}
    }
}