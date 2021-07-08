using System;

namespace Vexil
{
    public class VexilClient
    {
        private readonly IFeatureFlagProvider _featureFlagProvider;

        public VexilClient(
            IFeatureFlagProvider featureFlagProvider)
        {
            _featureFlagProvider = featureFlagProvider;
        }

        public bool IsEnabled(string flag)
        {
            if (_featureFlagProvider == null)
                return false;
            try
            {
                return _featureFlagProvider.IsEnabled(flag);
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
