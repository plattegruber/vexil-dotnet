using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Vexil.Plugins.Configuration.Configurations;

namespace Vexil.Plugins.Configuration
{
    public static class VexilBuilderExtension
    {
        public static VexilBuilder UseConfigurationProvider(this VexilBuilder vexilBuilder, IVexilContext vexilContext, IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>> configuration)
        {
            vexilBuilder.ConfiguredFeatureFlagProvider = new ConfigurationFeatureFlagProvider(new FeatureFlagManager(configuration), vexilContext);
            return vexilBuilder;
        }
    }
}
