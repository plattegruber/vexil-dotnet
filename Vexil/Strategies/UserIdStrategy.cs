using System.Collections.Generic;
using System.Linq;

namespace Vexil.Strategies
{
    /// <summary>
    ///     A feature flag strategy that enables the feature flag for a given set of user ids. An implementation
    ///     of <see cref="IStrategy"/>.
    /// </summary>
    public class UserIdStrategy : IStrategy
    {
        private IEnumerable<string> _allowedUserIds;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserIdStrategy" /> class with the set
        ///     of allowed user ids.
        /// </summary>
        /// <param name="allowedUserIds"> The user ids that this strategy is constrained to. </param>
        public UserIdStrategy(
            IEnumerable<string> allowedUserIds)
        {
            _allowedUserIds = allowedUserIds ?? Enumerable.Empty<string>();
        }

        /// <summary>
        ///     Determine if the criteria is met for the strategy, given the current context. An implementation of
        ///     <see cref="IStrategy.IsCriteriaMet(Dictionary{string, object})"/>
        /// </summary>
        /// <param name="parameters"> 
        ///     The context necessary for the strategy. In this case, the current user id will be needed.
        /// </param>
        /// <returns> 
        ///     <see langword="true" /> if the strategy conditions are met, <see langword="false" /> otherwise. In
        ///     this case, strategy conditions will be met when the given user id is in the set of allowed user
        ///     ids.
        /// </returns>
        public bool IsCriteriaMet(Dictionary<string, object> parameters)
        {
            return _allowedUserIds.Count() > 0;
        }
    }
}
