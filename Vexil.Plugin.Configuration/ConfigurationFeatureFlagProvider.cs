namespace Vexil.Plugins.Configuration
{
    public class ConfigurationFeatureFlagProvider : IFeatureFlagProvider
    {
        private readonly IFeatureFlagManager _featureFlagManager;

        public ConfigurationFeatureFlagProvider(
            IFeatureFlagManager featureFlagManager)
        {
            _featureFlagManager = featureFlagManager;
        }

        public bool IsEnabled(string featureFlag) =>
            _featureFlagManager.Get(featureFlag)?.AllStrategyConditionsMet() ?? false;
    }
}
