namespace Vexil.Plugins.Unleash
{
    public static class VexilBuilderExtension
    {
        public static VexilBuilder UseUnleash(this VexilBuilder vexilBuilder, IVexilContext vexilContext)
        {
            vexilBuilder.ConfiguredFeatureFlagProvider = new UnleashFeatureFlagProvider(new FeatureFlagStore(), new FeatureFlagService(), vexilContext);
            return vexilBuilder;
        }
    }
}
