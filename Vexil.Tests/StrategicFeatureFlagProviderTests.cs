using Moq;
using System.Collections.Concurrent;
using Xunit;

namespace Vexil.Tests
{
    public class StrategicFeatureFlagProviderTests
    {
        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenTheFlagIsMissing()
        {
            var featureFlags = new ConcurrentDictionary<string, FeatureFlag>();
            var sut = new StrategicFeatureFlagProvider(featureFlags);

            var isEnabled = sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenAStrategyConditionIsntMet()
        {
            var featureFlags = new ConcurrentDictionary<string, FeatureFlag>();
            featureFlags["flag"] = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == false);
            var sut = new StrategicFeatureFlagProvider(featureFlags);

            var isEnabled = sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnTrue_WhenStrategyConditionsAreAMet()
        {
            var featureFlags = new ConcurrentDictionary<string, FeatureFlag>();
            featureFlags["flag"] = Mock.Of<FeatureFlag>(f => f.AllStrategyConditionsMet() == true);
            var sut = new StrategicFeatureFlagProvider(featureFlags);

            var isEnabled = sut.IsEnabled("flag");

            Assert.True(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenThereAreNoFlags()
        {
            var featureFlags = new ConcurrentDictionary<string, FeatureFlag>();
            var sut = new StrategicFeatureFlagProvider(featureFlags);

            var isEnabled = sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenFlagsIsNull()
        {
            var sut = new StrategicFeatureFlagProvider(null);

            var isEnabled = sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }
    }
}
