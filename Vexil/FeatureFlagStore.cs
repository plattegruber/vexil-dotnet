using System.Collections.Concurrent;

namespace Vexil
{
    public class FeatureFlagStore : ConcurrentDictionary<string, FeatureFlag>, IFeatureFlagStore { }
}
