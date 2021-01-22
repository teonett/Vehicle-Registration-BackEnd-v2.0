using BE_Vehicle_Control.Shared.Commands.Contracts;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class BaseCommandResult : ICommandResult
    {
        public BaseCommandResult()
        {
        }
        
        public BaseCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}