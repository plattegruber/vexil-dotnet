using Moq;
using System;
using Xunit;

namespace Vexil.Tests
{
    public class VexilClientTests
    {
        private readonly Mock<IFeatureFlagProvider> _featureFlagProviderMock;
        private readonly VexilClient _sut;

        public VexilClientTests()
        {
            _featureFlagProviderMock = new Mock<IFeatureFlagProvider>();
            _sut = new VexilClient(_featureFlagProviderMock.Object);
        }

        [Fact]
        public void IsEnabled_ShouldReturnTrue_WhenTheFlagIsEnabled()
        {
            _featureFlagProviderMock.Setup(m => m.IsEnabled("flag")).Returns(true);

            var isEnabled = _sut.IsEnabled("flag");

            Assert.True(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenTheFlagIsDisabled()
        {
            _featureFlagProviderMock.Setup(m => m.IsEnabled("flag")).Returns(false);

            var isEnabled = _sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }

        [Fact]
        public void IsEnabled_ShouldReturnFalse_WhenTheFlagErrors()
        {
            _featureFlagProviderMock.Setup(m => m.IsEnabled("flag")).Throws<Exception>();

            var isEnabled = _sut.IsEnabled("flag");

            Assert.False(isEnabled);
        }
    }
}
