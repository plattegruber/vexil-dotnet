using System.Collections.Generic;

namespace Vexil.Strategies
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool IsCriteriaMet(Dictionary<string, object> parameters);
    }
}
