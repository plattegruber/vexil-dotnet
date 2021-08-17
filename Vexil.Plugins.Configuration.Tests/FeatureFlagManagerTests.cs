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
        private readonly FeatureFlagManager _sut;

        public FeatureFlagManagerTests()
        {
            _configurationMock = new Mock<IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>>>();
            _sut = new FeatureFlagManager(_configurationMock.Object);
        }

        [Fact]
        public void GetAll_ShouldReturn_AllFeatureFlags()
        {
            _configurationMock.SetupGet(m => m.Value).Returns(new List<FeatureFlagConfiguration>()
            {
                new()
                {
                    Name = "test",
                    StrategyConfigurations = new List<StrategyConfiguration>()
                    {
                        new()
                        {
                            Type = "userId",
                            PropertyConfigurations = new List<PropertyConfiguration>()
                            {
                                new()
                                {
                                    Name = "userIds",
                                    Value = new List<string>()
                                    {
                                        "123",
                                        "234",
                                        "345"
                                    }
                                }
                            }
                        }
                    }
                }
            });

            var featureFlags = _sut.GetAll();

            Assert.Collection(featureFlags, i => Assert.True(i.Name == "test"));
        }

        [Fact]
        public void GetAll_ShouldReturn_NoFeatureFlagsWhenNoneAreConfigured()
        {
            var featureFlags = _sut.GetAll();

            Assert.NotNull(featureFlags);
            Assert.Empty(featureFlags);
        }
    }
}
