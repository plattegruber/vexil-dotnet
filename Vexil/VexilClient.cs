using System;
using Vexil.Exceptions;

namespace Vexil
{
    /// <summary>
    ///     The entry point for consumers of the Vexil library.
    /// </summary>
    public class VexilClient
    {
        private readonly IFeatureFlagProvider _featureFlagProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VexilClient"/> class.
        /// </summary>
        /// <param name="featureFlagProvider"> The <see cref="IFeatureFlagProvider"/> to be configured as a plugin. </param>
        public VexilClient(
            IFeatureFlagProvider featureFlagProvider)
        {
            _featureFlagProvider = featureFlagProvider;
        }

        /// <summary>
        ///     <para>
        ///         Gets the current value of the requested feature flag by name.
        ///     </para>
        ///     <para>
        ///         If the feature flag is missing or the configured plugin throws an exception, this method will default to
        ///         <see langword="false" />. If the plugin failed to properly configure, a <see cref="MissingProviderException"/>
        ///         will be thrown.
        ///     </para>
        /// </summary>
        /// <exception cref="MissingProviderException"></exception>
        /// <param name="flag"> The slug or name of the feature flag. </param>
        /// <returns> <see langword="true" /> if the flag is enabled given the current context. <see langword="false" /> otherwise. </returns>
        public bool IsEnabled(string flag)
        {
            if (_featureFlagProvider == null)
                throw new MissingProviderException();
            try
            {
                return _featureFlagProvider.IsEnabled(flag);
            }
            catch(Exception e)
            {
                var exception = new ProviderException("The underlying feature flag provider threw an exception. Defaulting to false.", e);   
                Console.WriteLine(exception);
                return false;
            }
        }
    }
}
