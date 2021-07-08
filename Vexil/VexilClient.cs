using System;
using Vexil.Exceptions;

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
                throw new MissingProviderException();
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
