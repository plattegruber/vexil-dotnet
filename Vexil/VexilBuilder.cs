namespace Vexil
{
    /// <summary>
    ///     A builder for the <see cref="VexilClient"/>.
    /// </summary>
    public class VexilBuilder
    {
        /// <summary>
        ///     The <see cref="IFeatureFlagProvider"/> being configured.
        /// </summary>
        public IFeatureFlagProvider ConfiguredFeatureFlagProvider;

        /// <summary>
        ///     Sets the <see cref="IFeatureFlagProvider"/> to be used by the <see cref="VexilClient"/>.
        /// </summary>
        /// <param name="featureFlagProvider"> The <see cref="IFeatureFlagProvider"/> to be used. </param>
        /// <returns> The builder instance. </returns>
        public VexilBuilder UseFeatureFlagProvider(IFeatureFlagProvider featureFlagProvider)
        {
            this.ConfiguredFeatureFlagProvider = featureFlagProvider;
            return this;
        }

        /// <summary>
        ///     Gets the <see cref="VexilClient"/> being configured.
        /// </summary>
        /// <returns> The <see cref="VexilClient"/> being configured. </returns>
        public VexilClient Build()
            => new VexilClient(ConfiguredFeatureFlagProvider);
    }
}
