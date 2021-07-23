namespace Vexil.Plugins.Configuration
{
    public static class VexilBuilderExtension
    {
        public static VexilBuilder UseConfigurationProvider(this VexilBuilder vexilBuilder)
        {
            vexilBuilder.ConfiguredFeatureFlagProvider = new ConfigurationFeatureFlagProvider(new FeatureFlagManager());
            return vexilBuilder;
        }
    }
}
