using System.Collections.Generic;

namespace Vexil.Plugins.Configuration.Configurations
{
    public class StrategyConfiguration
    {
        public string Type { get; set; }
        public IEnumerable<PropertyConfiguration> PropertyConfigurations { get; set; }
    }
}
