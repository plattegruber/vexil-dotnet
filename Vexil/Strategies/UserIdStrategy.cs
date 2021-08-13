using System;
using System.Linq;
using System.Collections.Generic;

namespace Vexil.Strategies
{
    /// <summary>
    ///     A feature flag strategy that enables the feature flag for a given set of user ids. An implementation
    ///     of <see cref="IStrategy"/>.
    /// </summary>
    public record UserIdStrategy : IStrategy
    {
        /// <summary>
        ///     The set of user ids that are allowed to enable this flag.
        /// </summary>
        public virtual IEnumerable<string> AllowedUserIds { get; init; }

        /// <summary>
        ///     Initialize the UserIdStrategy with no AllowedUserIds.
        /// </summary>
        public UserIdStrategy() { }

        /// <summary>
        ///     Initialize the UserIdStrategy with a set of AllowedUserIds.
        /// </summary>
        /// <param name="allowedUserIds"></param>
        public UserIdStrategy(IEnumerable<string> allowedUserIds)
        {
            AllowedUserIds = allowedUserIds;
        }

        /// <summary>
        ///     Determine if the criteria is met for the strategy, given the current context. An implementation of
        ///     <see cref="IStrategy.IsCriteriaMet(IVexilContext)"/>
        /// </summary>
        /// <param name="vexilContext"> 
        ///     The context necessary for the strategy. In this case, the current user id will be needed.
        /// </param>
        /// <returns> 
        ///     <see langword="true" /> if the strategy conditions are met, <see langword="false" /> otherwise. In
        ///     this case, strategy conditions will be met when the given user id is in the set of allowed user
        ///     ids.
        /// </returns>
        public bool IsCriteriaMet(IVexilContext vexilContext)
        {
            return AllowedUserIds.Contains(vexilContext.UserId.Value);
        }
    }
}
