using System.Collections.Generic;
using System.Linq;
using Vexil.Strategies;

namespace Vexil
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public record FeatureFlag
    {
        /// <summary>
        /// TODO: XML docs
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// TODO: XML docs
        /// </summary>
        public IEnumerable<IStrategy> Strategies { get; set; }

        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <returns></returns>
        public virtual bool AllStrategyConditionsMet(IVexilContext context) => 
            Strategies != null 
            && Strategies.Any() 
            && Strategies.All(s => s.IsCriteriaMet(context));
    }
}
