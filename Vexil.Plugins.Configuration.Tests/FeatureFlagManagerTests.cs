using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using Vexil.Plugins.Configuration.Configurations;
using Xunit;

namespace Vexil.Plugins.Configuration.Tests
{
    public class FeatureFlagManagerTests
    {
        private readonly Mock<IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>>> _configurationMock;
        private readonly Mock<IFeatureFlagConfigurationConverter> _converterMock;

        public FeatureFlagManagerTests()
        {
            _configurationMock = new Mock<IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>>>();
            _converterMock = new Mock<IFeatureFlagConfigurationConverter>();
        }

        [Fact]
        public void GetAll_ShouldReturn_AllFeatureFlags()
        {
            var testFeatureFlagConfiguration = new FeatureFlagConfiguration()
            {
                Name = "test"
            };
            _configurationMock.SetupGet(m => m.Value).Returns(new List<FeatureFlagConfiguration>() { testFeatureFlagConfiguration });
            _converterMock.Setup(m => m.Convert(It.Is<FeatureFlagConfiguration>(i => i.Name == "test"))).Returns(new FeatureFlag()
            {
                Name = "test"
            });
            var _sut = new FeatureFlagManager(_configurationMock.Object, _converterMock.Object);

            var featureFlags = _sut.GetAll();

            Assert.Collection(featureFlags, i => Assert.True(i.Name == "test"));
        }

        [Fact]
        public void GetAll_ShouldReturn_NoFeatureFlagsWhenNoneAreConfigured()
        {
            var _sut = new FeatureFlagManager(_configurationMock.Object, _converterMock.Object);

            var featureFlags = _sut.GetAll();

            Assert.NotNull(featureFlags);
            Assert.Empty(featureFlags);
        }
    }
}
