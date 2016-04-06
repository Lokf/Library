namespace Lokf.Library.Contracts.Reports
{
    using System;

    /// <summary>
    /// Report for a user.
    /// </summary>
    public class UserReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserReport"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="personalIdentityNumber">The personal identity number.</param>
        public UserReport(Guid userId, string personalIdentityNumber)
        {
            UserId = userId;

            PersonalIdentityNumber = personalIdentityNumber;
        }

        /// <summary>
        /// Gets the personal identity number.
        /// </summary>
        public string PersonalIdentityNumber { get; }

        /// <summary>
        /// Gets the user ID.
        /// </summary>
        public Guid UserId { get; }
    }
}
