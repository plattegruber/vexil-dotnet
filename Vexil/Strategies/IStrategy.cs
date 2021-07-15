using System.Collections.Generic;

namespace Vexil.Strategies
{
    /// <summary>
    ///     A condition or constraint that enables feature flag when met.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        ///     Determine if the criteria is met for the strategy, given the current context. 
        /// </summary>
        /// <param name="parameters"> The context necessary for the strategy. </param>
        /// <returns> <see langword="true" /> if the strategy conditions are met, <see langword="false" /> otherwise. </returns>
        public bool IsCriteriaMet(Dictionary<string, object> parameters);
    }
}
