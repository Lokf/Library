namespace Lokf.Library.ReportingCaches
{
    using Contracts.Reports;
    using System;
    using System.Collections.Generic;

    public class UserReportCache
    {
        private readonly Dictionary<Guid, UserReport> _users = new Dictionary<Guid, UserReport>();

        public IReadOnlyCollection<UserReport> Users { get { return _users.Values; } }

        public void Add(UserReport user)
        {
            _users.Add(user.UserId, user);
        }

        public void Update(UserReport user)
        {
            _users[user.UserId] = user;
        }
    }
}
