using System.Collections.Generic;

namespace Vexil.Strategies
{
    public interface IStrategy
    {
        public bool IsCriteriaMet(Dictionary<string, object> parameters);
    }
}
