using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Vexil.Plugins.Configuration.Configurations;

namespace Vexil.Plugins.Configuration
{
    public class FeatureFlagManager : IFeatureFlagManager
    {
        public IEnumerable<FeatureFlagConfiguration> _configuredFeatureFlags;
        private readonly IFeatureFlagConfigurationConverter _converter;

        public FeatureFlagManager(
            IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>> configurationAccessor,
            IFeatureFlagConfigurationConverter converter)
        {
            _configuredFeatureFlags = configurationAccessor.Value;
            _converter = converter;
        }

        public IEnumerable<FeatureFlag> GetAll()
        {
            return _configuredFeatureFlags.Select(f => _converter.Convert(f));
        }

        public FeatureFlag Get(string featureFlag)
        {
            throw new NotImplementedException();
        }
    }
}
