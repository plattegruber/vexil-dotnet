using System.Threading.Tasks;

namespace Vexil
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class StrategicFeatureFlagProvider : IFeatureFlagProvider
    {
        private IFeatureFlagStore _featureFlagStore;
        private IFeatureFlagService _featureFlagService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featureFlagStore"></param>
        /// <param name="featureFlagService"></param>
        public StrategicFeatureFlagProvider(
            IFeatureFlagStore featureFlagStore,
            IFeatureFlagService featureFlagService)
        {
            _featureFlagStore = featureFlagStore;
            _featureFlagService = featureFlagService;
            DiscoverAllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featureFlag"></param>
        /// <returns></returns>
        public virtual bool IsEnabled(string featureFlag)
        {
            return _featureFlagStore != null
                && _featureFlagStore.ContainsKey(featureFlag)
                && _featureFlagStore[featureFlag].AllStrategyConditionsMet();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task DiscoverAllAsync()
        {
            var featureFlags = await _featureFlagService.GetAsync();
            foreach (var featureFlag in featureFlags)
            {
                _featureFlagStore.Add(featureFlag.Name, featureFlag);
            }
        }
    }
}
