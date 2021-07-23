using Moq;
using Xunit;

namespace Vexil.Plugins.Configuration.Tests
{
    public class ConfigurationFeatureFlagProviderTests
    {
        [Fact]
        public void IsEnabled_ShouldReturnTrue_IfTheFeatureFlagIsEnabled()
        {
            var _featureFlagMock = new Mock<FeatureFlag>();
            _featureFlagMock.SetupGet(m => m.Name).Returns("test-flag");
            _featureFlagMock.Setup(m => m.AllStrategyConditionsMet()).Returns(true);
            var _featureFlagManagerMock = new Mock<IFeatureFlagManager>();
            _featureFlagManagerMock.Setup(m => m.Get("test-flag")).Returns( _featureFlagMock.Object );
            var sut = new ConfigurationFeatureFlagProvider(_featureFlagManagerMock.Object);

            var isEnabled = sut.IsEnabled("test-flag");

            Assert.True(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_IfTheFeatureFlagIsDisabled()
        {
            var _featureFlagMock = new Mock<FeatureFlag>();
            _featureFlagMock.SetupGet(m => m.Name).Returns("test-flag");
            _featureFlagMock.Setup(m => m.AllStrategyConditionsMet()).Returns(false);
            var _featureFlagManagerMock = new Mock<IFeatureFlagManager>();
            _featureFlagManagerMock.Setup(m => m.Get("test-flag")).Returns(_featureFlagMock.Object);
            var sut = new ConfigurationFeatureFlagProvider(_featureFlagManagerMock.Object);

            var isEnabled = sut.IsEnabled("test-flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_IfTheFlagIsNotFound()
        {
            var _featureFlagManagerMock = new Mock<IFeatureFlagManager>();
            _featureFlagManagerMock.Setup(m => m.Get("test-flag")).Returns<FeatureFlag>(null);
            var sut = new ConfigurationFeatureFlagProvider(_featureFlagManagerMock.Object);

            var isEnabled = sut.IsEnabled("test-flag");

            Assert.False(isEnabled);
        }
    }
}
