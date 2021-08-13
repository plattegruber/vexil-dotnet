using Moq;
using System.Collections.Generic;
using Vexil.Strategies;
using Xunit;

namespace Vexil.Tests
{
    public class FeatureFlagTests
    {
        private readonly IVexilContext _vexilContextDummy;

        public FeatureFlagTests()
        {
            _vexilContextDummy = It.IsAny<IVexilContext>();
        }

        [Fact]
        public void AllStrategyConditionsMet_ShouldReturnTrue_IfAllStrategyConditionsAreMet()
        {
            var strategies = new List<IStrategy>()
            {
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(_vexilContextDummy) == true),
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(_vexilContextDummy) == true)
            };
            var sut = new FeatureFlag()
            {
                Strategies = strategies
            };

            var isEnabled = sut.AllStrategyConditionsMet(_vexilContextDummy);

            Assert.True(isEnabled);
        }

        [Fact]
        public void AllStrategyConditionsMet_ShouldReturnFalse_IfAnyStrategyConditionIsntMet()
        {
            var strategies = new List<IStrategy>()
            {
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(_vexilContextDummy) == false),
                Mock.Of<IStrategy>(s => s.IsCriteriaMet(_vexilContextDummy) == true)
            };
            var sut = new FeatureFlag()
            {
                Strategies = strategies
            };

            var isEnabled = sut.AllStrategyConditionsMet(_vexilContextDummy);

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

            var isEnabled = sut.AllStrategyConditionsMet(_vexilContextDummy);

            Assert.False(isEnabled);
        }

        [Fact]
        public void AllStrategyConditionsMet_ShouldReturnFalse_IfStrategiesIsNull()
        {
            var sut = new FeatureFlag()
            {
                Strategies = null
            };

            var isEnabled = sut.AllStrategyConditionsMet(_vexilContextDummy);

            Assert.False(isEnabled);
        }
    }
}
