using System;
using System.Collections.Concurrent;

namespace Vexil
{
    public class StrategicFeatureFlagProvider : IFeatureFlagProvider
    {
        private ConcurrentDictionary<string, FeatureFlag> _featureFlags = new ConcurrentDictionary<string, FeatureFlag>();

        public StrategicFeatureFlagProvider(
            ConcurrentDictionary<string, FeatureFlag> featureFlags)
        {
            _featureFlags = featureFlags;
        }

        public bool IsEnabled(string featureFlag)
        {
            return _featureFlags != null
                && _featureFlags.ContainsKey(featureFlag) 
                && _featureFlags[featureFlag].AllStrategyConditionsMet();
        }
    }
}
