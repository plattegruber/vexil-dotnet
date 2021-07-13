using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vexil
{
    public interface IFeatureFlagService
    {
        Task<IEnumerable<FeatureFlag>> GetAsync();
    }
}