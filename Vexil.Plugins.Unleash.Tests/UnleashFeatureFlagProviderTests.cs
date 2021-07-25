using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Vexil.Plugins.Unleash.Tests
{
    public class UnleashFeatureFlagProviderTests
    {
        private readonly Mock<IFeatureFlagStore> _featureFlagStoreMock;
        private readonly Mock<IFeatureFlagService> _featureFlagServiceMock;
        private readonly UnleashFeatureFlagProvider _sut;

        public UnleashFeatureFlagProviderTests()
        {
            _featureFlagStoreMock = new Mock<IFeatureFlagStore>();
            _featureFlagServiceMock = new Mock<IFeatureFlagService>();
            _sut = new UnleashFeatureFlagProvider(_featureFlagStoreMock.Object, _featureFlagServiceMock.Object);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenTheFlagIsMissing()
        {
            var targetFlag = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == true);
            targetFlag.Name = "wrong-flag";
            _featureFlagStoreMock.SetupGet(m => m["wrong-flag"]).Returns(targetFlag);
            _featureFlagStoreMock.Setup(m => m.ContainsKey("wrong-flag")).Returns(true);
            _featureFlagServiceMock.Setup(m => m.GetAsync()).ReturnsAsync(new List<FeatureFlag>().AsEnumerable());

            var isEnabled = _sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenAStrategyConditionIsntMet()
        {
            var targetFlag = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == false);
            targetFlag.Name = "flag";
            _featureFlagStoreMock.SetupGet(m => m["flag"]).Returns(targetFlag);
            _featureFlagStoreMock.Setup(m => m.ContainsKey("flag")).Returns(false);

            var isEnabled = _sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnTrue_WhenStrategyConditionsAreAMet()
        {
            var targetFlag = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == true && f.Name == "flag");
            _featureFlagStoreMock.SetupGet(m => m["flag"]).Returns(targetFlag);
            _featureFlagStoreMock.Setup(m => m.ContainsKey("flag")).Returns(true);

            var isEnabled = _sut.IsEnabled("flag");

            Assert.True(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenThereAreNoFlags()
        {
            var isEnabled = _sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }
    }
}
