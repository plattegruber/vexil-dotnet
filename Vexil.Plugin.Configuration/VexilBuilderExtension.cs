namespace Vexil.Plugins.Configuration
{
    public static class VexilBuilderExtension
    {
        public static VexilBuilder UseConfiguration(this VexilBuilder vexilBuilder)
        {
            vexilBuilder.ConfiguredFeatureFlagProvider = new FeatureFlagProvider();
            return vexilBuilder;
        }
    }
}
