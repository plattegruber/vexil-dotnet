using Vexil.Plugins.Configuration.Configurations;

namespace Vexil.Plugins.Configuration
{
    public interface IFeatureFlagConfigurationConverter
    {
        FeatureFlag Convert(FeatureFlagConfiguration configuration);
    }
}
