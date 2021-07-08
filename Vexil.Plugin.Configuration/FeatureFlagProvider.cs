namespace Vexil.Plugins.Configuration
{
    public class FeatureFlagProvider : IFeatureFlagProvider
    {
        public bool IsEnabled(string featureFlag) =>
            featureFlag.Equals("testFlag");
    }
}
