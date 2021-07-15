using System.Collections.Concurrent;

namespace Vexil
{
    /// <summary>
    ///     An in-memory store of feature flags. An implementation of <see cref="IFeatureFlagStore"/>
    /// </summary>
    public class FeatureFlagStore : ConcurrentDictionary<string, FeatureFlag>, IFeatureFlagStore { }
}
