using Moq;
using System.Collections.Generic;
using Vexil.Strategies;
using Xunit;

namespace Vexil.Tests
{
    public class FeatureFlagTests
    {
        [Fact]
        public void AllStrategyConditionsMet_ShouldReturnTrue_IfAllStrategyConditionsAreMet()
        {
            var strategies = new List<IStrategy>()
            {
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(It.IsAny<IVexilContext>()) == true),
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(It.IsAny<IVexilContext>()) == true)
            };
            var sut = new FeatureFlag()
            {
                Strategies = strategies
            };

            var isEnabled = sut.AllStrategyConditionsMet();

            Assert.True(isEnabled);
        }

        [Fact]
        public void AllStrategyConditionsMet_ShouldReturnFalse_IfAnyStrategyConditionIsntMet()
        {
            var strategies = new List<IStrategy>()
            {
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(It.IsAny<IVexilContext>()) == false),
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(It.IsAny<IVexilContext>()) == true)
            };
            var sut = new FeatureFlag()
            {
                Strategies = strategies
            };

            var isEnabled = sut.AllStrategyConditionsMet();

            Assert.False(isEnabled);
        }

        [Fact]
        public void AllStrategyConditionsMet_ShouldReturnFalse_IfThereAreNoStrategies()
        {
            var strategies = new List<IStrategy>() { };
            var sut = new FeatureFlag()
            {
                Strategies = strategies
            };

            var isEnabled = sut.AllStrategyConditionsMet();

            Assert.False(isEnabled);
        }

        [Fact]
        public void AllStrategyConditionsMet_ShouldReturnFalse_IfStrategiesIsNull()
        {
            var sut = new FeatureFlag()
            {
                Strategies = null
            };

            var isEnabled = sut.AllStrategyConditionsMet();

            Assert.False(isEnabled);
        }
    }
}
