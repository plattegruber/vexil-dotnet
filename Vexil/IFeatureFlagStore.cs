using System.Collections.Generic;

namespace Vexil
{
    public interface IFeatureFlagStore : IDictionary<string, FeatureFlag> { }
}
