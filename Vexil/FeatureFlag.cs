using System.Collections.Generic;
using System.Linq;
using Vexil.Strategies;

namespace Vexil
{
    public class FeatureFlag
    {
        public string Name { get; set; }
        public IEnumerable<IStrategy> Strategies { get; set; }
        public virtual bool AllStrategyConditionsMet() => 
            Strategies != null 
            && Strategies.Any() 
            && Strategies.All(s => s.IsCriteriaMet(null));
    }
}
