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
            return _featureFlagProvider.IsEnabled(flag);
        }
    }
}
