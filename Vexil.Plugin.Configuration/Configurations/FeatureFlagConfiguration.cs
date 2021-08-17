using System.Collections.Generic;

namespace Vexil.Plugins.Configuration.Configurations
{
    public class FeatureFlagConfiguration
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public IEnumerable<StrategyConfiguration> StrategyConfigurations { get; set; }
    }
}
