using System.Collections.Generic;

namespace Vexil
{
    /// <summary>
    ///     An in-memory store of feature flags.
    /// </summary>
    public interface IFeatureFlagStore : IDictionary<string, FeatureFlag> { }
}
