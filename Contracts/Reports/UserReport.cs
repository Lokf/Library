namespace Lokf.Library.Contracts.Reports
{
    using System;

    public class UserReport
    {
        public UserReport(Guid userId, string personalIdentityNumber)
        {
            UserId = userId;

            PersonalIdentityNumber = personalIdentityNumber;
        }

        public string PersonalIdentityNumber { get; }

        public Guid UserId { get; }
    }
}
