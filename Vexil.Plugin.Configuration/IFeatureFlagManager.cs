using System.Collections.Generic;

namespace Vexil.Plugins.Configuration
{
    public interface IFeatureFlagManager
    {
        IEnumerable<FeatureFlag> GetAll();
        FeatureFlag Get(string featureFlag);
    }
}
