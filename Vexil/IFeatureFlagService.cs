using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vexil
{
    /// <summary>
    ///     A service that coordinates the fetching of feature flags from their source.
    /// </summary>
    public interface IFeatureFlagService
    {
        /// <summary>
        ///     Retreive the set of feature flags from their source.
        /// </summary>
        /// <returns> A set of <see cref="FeatureFlag"/>s. </returns>
        Task<IEnumerable<FeatureFlag>> GetAsync();
    }
}