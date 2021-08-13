using Moq;
using Xunit;

namespace Vexil.Plugins.Unleash.Tests
{
    public class VexilBuilderExtensionTests
    {
        private readonly IVexilContext _vexilContextDummy;

        public VexilBuilderExtensionTests()
        {
            _vexilContextDummy = It.IsAny<IVexilContext>();
        }

        [Fact]
        public void UseUnleash_ShouldReturn_This()
        {
            var sut = new VexilBuilder();

            var fluent = sut.UseUnleash(_vexilContextDummy);

            Assert.Equal(sut, fluent);
        }

        [Fact]
        public void UseUnleash_ShouldConfigure_TheUnleashFeatureFlagProvider()
        {
            var sut = new VexilBuilder();

            sut.UseUnleash(_vexilContextDummy);

            Assert.NotNull(sut.ConfiguredFeatureFlagProvider);
            Assert.IsType<UnleashFeatureFlagProvider>(sut.ConfiguredFeatureFlagProvider);
        }
    }
}
