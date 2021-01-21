using BE_Vehicle_Control.Shared.Commands.Contracts;

namespace BE_Vehicle_Control.Shared.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Commands.Contracts.ICommandResult Handle(T command);
    }
}