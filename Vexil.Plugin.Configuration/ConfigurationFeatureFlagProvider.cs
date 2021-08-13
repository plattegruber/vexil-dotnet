namespace Vexil.Plugins.Configuration
{
    public class ConfigurationFeatureFlagProvider : IFeatureFlagProvider
    {
        private readonly IFeatureFlagManager _featureFlagManager;
        private readonly IVexilContext _vexilContext;

        public ConfigurationFeatureFlagProvider(
            IFeatureFlagManager featureFlagManager,
            IVexilContext vexilContext)
        {
            _featureFlagManager = featureFlagManager;
            _vexilContext = vexilContext;
        }

        public bool IsEnabled(string featureFlag) =>
            _featureFlagManager.Get(featureFlag)?.AllStrategyConditionsMet(_vexilContext) ?? false;
    }
}
