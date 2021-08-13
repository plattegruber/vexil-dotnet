namespace Vexil.Plugins.Unleash
{
    public class UnleashFeatureFlagProvider : StrategicFeatureFlagProvider
    {
        public UnleashFeatureFlagProvider(IFeatureFlagStore featureFlagStore, IFeatureFlagService featureFlagService, IVexilContext vexilContext) 
            : base(featureFlagStore, featureFlagService, vexilContext)
        {
        }
    }
}
