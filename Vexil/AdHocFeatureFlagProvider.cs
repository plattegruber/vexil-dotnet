using System;

namespace Vexil
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public abstract class AdHocFeatureFlagProvider : IFeatureFlagProvider
    {
        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <param name="featureFlag"></param>
        /// <returns></returns>
        public virtual bool IsEnabled(string featureFlag)
        {
            throw new NotImplementedException();
        }
    }
}
 