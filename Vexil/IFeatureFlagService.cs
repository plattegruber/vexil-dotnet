using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vexil
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public interface IFeatureFlagService
    {
        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FeatureFlag>> GetAsync();
    }
}