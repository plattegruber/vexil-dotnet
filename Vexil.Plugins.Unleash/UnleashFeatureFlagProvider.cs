namespace Vexil.Plugins.Unleash
{
    public class UnleashFeatureFlagProvider : StrategicFeatureFlagProvider
    {
        public UnleashFeatureFlagProvider(IFeatureFlagStore featureFlagStore, IFeatureFlagService featureFlagService) 
            : base(featureFlagStore, featureFlagService)
        {
        }
    }
}
