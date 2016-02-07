namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    /// <summary>
    /// A message containing the necessary information for register a new user.
    /// </summary>
    public sealed class RegisterUserCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserCommand"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="personalIdentityNumber">The personalIdentityNumber.</param>
        public RegisterUserCommand(Guid userId, string personalIdentityNumber)
        {
            AggregateId = userId;

            PersonalIdentityNumber = personalIdentityNumber;
        }

        /// <summary>
        /// Gets the aggregate ID.
        /// </summary>
        public Guid AggregateId { get; }

        /// <summary>
        /// Gets the personalIdentityNumber.
        /// </summary>
        public string PersonalIdentityNumber { get; }
    }
}
