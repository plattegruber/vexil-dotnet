using System.Collections.Generic;
using System.Threading.Tasks;
using Vexil.Strategies;

namespace Vexil
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public class FeatureFlagService : IFeatureFlagService
    {
        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<FeatureFlag>> GetAsync()
        {
            await Task.CompletedTask;
            return new List<FeatureFlag>()
            {
                new FeatureFlag()
                {
                    Name = "testFlag",
                    Strategies = new List<IStrategy>()
                    {
                        new UserIdStrategy(new List<string>() { "1" })
                    }
                }
            };
        }
    }
}
