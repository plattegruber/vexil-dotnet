using System.Collections.Concurrent;

namespace Vexil
{
    /// <summary>
    /// TODO: xml docs
    /// </summary>
    public class FeatureFlagStore : ConcurrentDictionary<string, FeatureFlag>, IFeatureFlagStore { }
}
