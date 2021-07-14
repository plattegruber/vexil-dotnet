namespace Vexil
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public interface IFeatureFlagProvider
    {
        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <param name="featureFlag"></param>
        /// <returns></returns>
        bool IsEnabled(string featureFlag);
    }
}
