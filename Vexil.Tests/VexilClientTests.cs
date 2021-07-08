using Moq;
using System;
using Xunit;

namespace Vexil.Tests
{
    public class VexilClientTests
    {
        [Fact]
        public void IsEnabled_ShouldReturnTrue_WhenTheFlagIsEnabled()
        {
            var featureFlagProviderMock = new Mock<IFeatureFlagProvider>();
            featureFlagProviderMock.Setup(m => m.IsEnabled("flag")).Returns(true);
            var vexilClient = new VexilClient(featureFlagProvider: featureFlagProviderMock.Object);

            var isEnabled = vexilClient.IsEnabled("flag");

            Assert.True(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenTheFlagIsDisabled()
        {
            var featureFlagProviderMock = new Mock<IFeatureFlagProvider>();
            featureFlagProviderMock.Setup(m => m.IsEnabled("flag")).Returns(false);
            var vexilClient = new VexilClient(featureFlagProvider: featureFlagProviderMock.Object);

            var isEnabled = vexilClient.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenTheFlagErrors()
        {
            var featureFlagProviderMock = new Mock<IFeatureFlagProvider>();
            featureFlagProviderMock.Setup(m => m.IsEnabled("flag")).Throws<Exception>();
            var vexilClient = new VexilClient(featureFlagProvider: featureFlagProviderMock.Object);

            var isEnabled = vexilClient.IsEnabled("flag");

            Assert.False(isEnabled);
        }
    }
}
