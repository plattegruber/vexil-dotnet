using Xunit;

namespace Vexil.Plugins.Unleash.Tests
{
    public class VexilBuilderExtensionTests
    {
        [Fact]
        public void UseUnleash_ShouldReturn_This()
        {
            var sut = new VexilBuilder();

            var fluent = sut.UseUnleash();

            Assert.Equal(sut, fluent);
        }

        [Fact]
        public void UseUnleash_ShouldConfigure_TheUnleashFeatureFlagProvider()
        {
            var sut = new VexilBuilder();

            sut.UseUnleash();

            Assert.NotNull(sut.ConfiguredFeatureFlagProvider);
            Assert.IsType<UnleashFeatureFlagProvider>(sut.ConfiguredFeatureFlagProvider);
        }
    }
}
