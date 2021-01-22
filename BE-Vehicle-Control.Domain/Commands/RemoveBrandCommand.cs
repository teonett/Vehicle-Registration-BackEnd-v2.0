using System;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class RemoveBrandCommand : Notifiable, ICommand
    {
        public RemoveBrandCommand()
        {
            
        }

        public RemoveBrandCommand(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
            );
        }
    }
}