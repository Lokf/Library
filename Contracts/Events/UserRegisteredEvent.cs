namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Event for a user have been registered.
    /// </summary>
    public sealed class UserRegisteredEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegisteredEvent"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="personalIdentityNumber">The personal identity number.</param>
        public UserRegisteredEvent(Guid userId, string personalIdentityNumber)
            : base(userId)
        {
            PersonalIdentityNumber = personalIdentityNumber;
        }

        /// <summary>
        /// Gets the personal identity number.
        /// </summary>
        public string PersonalIdentityNumber { get; }
    }
}
