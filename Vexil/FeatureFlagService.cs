using System.Collections.Generic;
using System.Threading.Tasks;
using Vexil.Strategies;

namespace Vexil
{
    public class FeatureFlagService : IFeatureFlagService
    {
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
