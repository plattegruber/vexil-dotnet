using System.Threading.Tasks;

namespace Vexil
{
    public abstract class StrategicFeatureFlagProvider : IFeatureFlagProvider
    {
        private IFeatureFlagStore _featureFlagStore;
        private IFeatureFlagService _featureFlagService;

        public StrategicFeatureFlagProvider(
            IFeatureFlagStore featureFlagStore,
            IFeatureFlagService featureFlagService)
        {
            _featureFlagStore = featureFlagStore;
            _featureFlagService = featureFlagService;
            DiscoverAllAsync().ConfigureAwait(false);
        }

        public bool IsEnabled(string featureFlag)
        {
            return _featureFlagStore != null
                && _featureFlagStore.ContainsKey(featureFlag)
                && _featureFlagStore[featureFlag].AllStrategyConditionsMet();
        }

        public async Task DiscoverAllAsync()
        {
            var featureFlags = await _featureFlagService.GetAsync();
            foreach (var featureFlag in featureFlags)
            {
                _featureFlagStore.Add(featureFlag.Name, featureFlag);
            }
        }
    }
}
