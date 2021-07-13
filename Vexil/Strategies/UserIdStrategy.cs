using System;
using System.Collections.Generic;
using System.Linq;

namespace Vexil.Strategies
{
    public class UserIdStrategy : IStrategy
    {
        private IEnumerable<string> _allowedUserIds;

        public UserIdStrategy(
            IEnumerable<string> allowedUserIds)
        {
            _allowedUserIds = allowedUserIds;
        }

        public bool IsCriteriaMet(Dictionary<string, object> parameters)
        {
            return _allowedUserIds.Count() > 0;
        }
    }
}
