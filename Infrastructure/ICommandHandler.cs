namespace Lokf.Library.Infrastructure
{
    /// <summary>
    /// A command handler handles commands.
    /// </summary>
    /// <typeparam name="TCommand">The type of command to handle.</typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        void Handle(TCommand command);
    }
}
