namespace Vexil.Plugins.Configuration
{
    public class ConfigurationFeatureFlagProvider : IFeatureFlagProvider
    {
        public bool IsEnabled(string featureFlag) =>
            featureFlag.Equals("testFlag");
    }
}
