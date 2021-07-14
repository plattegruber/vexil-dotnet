using System;
using System.Collections.Generic;
using System.Linq;

namespace Vexil.Strategies
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public class UserIdStrategy : IStrategy
    {
        private IEnumerable<string> _allowedUserIds;

        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <param name="allowedUserIds"></param>
        public UserIdStrategy(
            IEnumerable<string> allowedUserIds)
        {
            _allowedUserIds = allowedUserIds;
        }

        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool IsCriteriaMet(Dictionary<string, object> parameters)
        {
            return _allowedUserIds.Count() > 0;
        }
    }
}
