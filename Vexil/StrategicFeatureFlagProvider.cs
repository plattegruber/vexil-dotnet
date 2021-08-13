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
        private IVexilContext _vexilContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featureFlagStore"></param>
        /// <param name="featureFlagService"></param>
        /// <param name="vexilContext"></param>
        public StrategicFeatureFlagProvider(
            IFeatureFlagStore featureFlagStore,
            IFeatureFlagService featureFlagService,
            IVexilContext vexilContext)
        {
            _featureFlagStore = featureFlagStore;
            _featureFlagService = featureFlagService;
            _vexilContext = vexilContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featureFlag"></param>
        /// <returns></returns>
        public virtual bool IsEnabled(string featureFlag)
        {
            if (_featureFlagStore.Count == 0)
                DiscoverAllAsync().ConfigureAwait(false);
            return _featureFlagStore != null
                && _featureFlagStore.ContainsKey(featureFlag)
                && _featureFlagStore[featureFlag].AllStrategyConditionsMet(_vexilContext);
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
