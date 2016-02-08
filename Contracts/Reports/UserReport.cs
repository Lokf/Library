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

        public Guid UserId { get; }

        public string PersonalIdentityNumber { get; }
    }
}
