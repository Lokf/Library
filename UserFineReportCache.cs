namespace Lokf.Library.ReportingCaches
{
    using Contracts.Reports;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserFineReportCache
    {
        private Dictionary<Guid, List<UserFineReport>> _userFines = new Dictionary<Guid, List<UserFineReport>>();

        public void Add(UserFineReport userFineReport)
        {
            List<UserFineReport> userFines;

            if (_userFines.TryGetValue(userFineReport.UserId, out userFines))
            {
                userFines.Add(userFineReport);
            }
            else
            {
                _userFines.Add(userFineReport.UserId, new List<UserFineReport> { userFineReport });
            }
        }

        public IEnumerable<UserFineReport> GetUserFineReportsForUser(Guid userId)
        {
            List<UserFineReport> userFines;

            if (_userFines.TryGetValue(userId, out userFines))
            {
                return userFines;
            }

            return Enumerable.Empty<UserFineReport>();
        }
    }
}
