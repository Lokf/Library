namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    public sealed class UserRegisteredEvent : DomainEvent
    {
        public UserRegisteredEvent(Guid userId, string personalIdentityNumber)
            : base(userId)
        {
            PersonalIdentityNumber = personalIdentityNumber;
        }

        public string PersonalIdentityNumber { get; }
    }
}
