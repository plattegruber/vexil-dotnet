using System;

namespace Vexil
{
    public abstract class AdHocFeatureFlagProvider : IFeatureFlagProvider
    {
        public virtual bool IsEnabled(string featureFlag)
        {
            throw new NotImplementedException();
        }
    }
}
 