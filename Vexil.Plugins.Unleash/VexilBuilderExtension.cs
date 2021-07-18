namespace Vexil.Plugins.Unleash
{
    public static class VexilBuilderExtension
    {
        public static VexilBuilder UseUnleash(this VexilBuilder vexilBuilder)
        {
            vexilBuilder.ConfiguredFeatureFlagProvider = new UnleashFeatureFlagProvider(new FeatureFlagStore(), new FeatureFlagService());
            return vexilBuilder;
        }
    }
}
