using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Vexil.Plugins.Configuration.Configurations;

namespace Vexil.Plugins.Configuration
{
    public class FeatureFlagManager : IFeatureFlagManager
    {
        private readonly IEnumerable<FeatureFlagConfiguration> _configuredFeatureFlags;

        public FeatureFlagManager(
            IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>> configurationAccessor)
        {
            _configuredFeatureFlags = configurationAccessor.Value;
        }

        public IEnumerable<FeatureFlag> GetAll()
        {
            return _configuredFeatureFlags;
        }

        public FeatureFlag Get(string featureFlag)
        {
            throw new NotImplementedException();
        }
    }
}
