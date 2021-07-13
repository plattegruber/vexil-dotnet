using Moq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Vexil.Plugins.Unleash.Tests
{
    public class UnleashFeatureFlagProviderTests
    {
        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenTheFlagIsMissing()
        {
            var featureFlagStoreMock = new Mock<FeatureFlagStore>();
            var featureFlagServiceMock = new Mock<FeatureFlagService>();
            var targetFlag = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == true);
            targetFlag.Name = "wrong-flag";
            featureFlagServiceMock.Setup(m => m.GetAsync()).ReturnsAsync(new List<FeatureFlag>()
            {
                targetFlag
            }.AsEnumerable());
            featureFlagServiceMock.Setup(m => m.GetAsync()).ReturnsAsync(new List<FeatureFlag>().AsEnumerable());

            var sut = new UnleashFeatureFlagProvider(featureFlagStoreMock.Object, featureFlagServiceMock.Object);

            var isEnabled = sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenAStrategyConditionIsntMet()
        {
            var featureFlagStoreMock = new Mock<FeatureFlagStore>();
            var featureFlagServiceMock = new Mock<FeatureFlagService>();
            var targetFlag = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == false);
            targetFlag.Name = "flag";
            featureFlagServiceMock.Setup(m => m.GetAsync()).ReturnsAsync(new List<FeatureFlag>()
            {
                targetFlag
            }.AsEnumerable());
            var sut = new UnleashFeatureFlagProvider(featureFlagStoreMock.Object, featureFlagServiceMock.Object);

            var isEnabled = sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnTrue_WhenStrategyConditionsAreAMet()
        {
            var featureFlagStoreMock = new Mock<FeatureFlagStore>();
            var featureFlagServiceMock = new Mock<FeatureFlagService>();
            var targetFlag = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == true);
            targetFlag.Name = "flag";
            featureFlagServiceMock.Setup(m => m.GetAsync()).ReturnsAsync(new List<FeatureFlag>()
            {
                targetFlag
            }.AsEnumerable());
            var sut = new UnleashFeatureFlagProvider(featureFlagStoreMock.Object, featureFlagServiceMock.Object);

            var isEnabled = sut.IsEnabled("flag");

            Assert.True(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenThereAreNoFlags()
        {
            var featureFlagStoreMock = new Mock<FeatureFlagStore>();
            var featureFlagServiceMock = new Mock<FeatureFlagService>();
            featureFlagServiceMock.Setup(m => m.GetAsync()).ReturnsAsync(new List<FeatureFlag>().AsEnumerable());
            var sut = new UnleashFeatureFlagProvider(featureFlagStoreMock.Object, featureFlagServiceMock.Object);

            var isEnabled = sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }
    }
}
