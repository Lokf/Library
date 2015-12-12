namespace Lokf.Library.User.Events
{
    using Infrastructure;
    using System;

    public sealed class UserRegisteredEvent : DomainEvent
    {
        public string PersonalIdentityNumber { get; }

        public UserRegisteredEvent(Guid userId, string personalIdentityNumber) 
            : base(userId)
        {
            PersonalIdentityNumber = personalIdentityNumber;
        }
    }
}
