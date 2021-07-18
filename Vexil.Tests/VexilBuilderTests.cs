using Xunit;

namespace Vexil.Tests
{
    public class VexilBuilderTests
    {
        [Fact]
        public void UseFeatureFlagProvider_ShouldReturn_This()
        {
            var sut = new VexilBuilder();

            var fluent = sut.UseFeatureFlagProvider(null);

            Assert.Equal(sut, fluent);
        }

        [Fact]
        public void Build_Should_ReturnAVexilClient()
        {
            var sut = new VexilBuilder();

            var vexilClient = sut.Build();

            Assert.IsType<VexilClient>(vexilClient);
        }
    }
}
