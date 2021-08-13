namespace Vexil.Plugins.Configuration
{
    public static class VexilBuilderExtension
    {
        public static VexilBuilder UseConfigurationProvider(this VexilBuilder vexilBuilder, IVexilContext vexilContext)
        {
            vexilBuilder.ConfiguredFeatureFlagProvider = new ConfigurationFeatureFlagProvider(new FeatureFlagManager(), vexilContext);
            return vexilBuilder;
        }
    }
}
