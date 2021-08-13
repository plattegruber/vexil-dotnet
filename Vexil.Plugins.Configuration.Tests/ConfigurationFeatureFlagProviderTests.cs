using Moq;
using Xunit;

namespace Vexil.Plugins.Configuration.Tests
{
    public class ConfigurationFeatureFlagProviderTests
    {
        private readonly Mock<FeatureFlag> _featureFlagMock;
        private readonly Mock<IFeatureFlagManager> _featureFlagManagerMock;
        private readonly IVexilContext _vexilContextDummy;
        private readonly ConfigurationFeatureFlagProvider _sut;

        public ConfigurationFeatureFlagProviderTests()
        {
            _featureFlagMock = new Mock<FeatureFlag>();
            _featureFlagManagerMock = new Mock<IFeatureFlagManager>();
            _featureFlagMock.SetupGet(m => m.Name).Returns("test-flag");
            _vexilContextDummy = It.IsAny<IVexilContext>();
            _sut = new ConfigurationFeatureFlagProvider(_featureFlagManagerMock.Object, null);
        }

        [Fact]
        public void IsEnabled_ShouldReturnTrue_IfTheFeatureFlagIsEnabled()
        {
            _featureFlagManagerMock.Setup(m => m.Get("test-flag")).Returns(_featureFlagMock.Object);
            _featureFlagMock.Setup(m => m.AllStrategyConditionsMet(_vexilContextDummy)).Returns(true);

            var isEnabled = _sut.IsEnabled("test-flag");

            Assert.True(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_IfTheFeatureFlagIsDisabled()
        {
            _featureFlagManagerMock.Setup(m => m.Get("test-flag")).Returns(_featureFlagMock.Object);
            _featureFlagMock.Setup(m => m.AllStrategyConditionsMet(_vexilContextDummy)).Returns(false);

            var isEnabled = _sut.IsEnabled("test-flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_IfTheFlagIsNotFound()
        {
            _featureFlagManagerMock.Setup(m => m.Get("test-flag")).Returns<FeatureFlag>(null);

            var isEnabled = _sut.IsEnabled("test-flag");

            Assert.False(isEnabled);
        }
    }
}
