using System;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class RemoveVehicleModelCommand : Notifiable, ICommand
    {
        public RemoveVehicleModelCommand()
        {
            
        }

        public RemoveVehicleModelCommand(Guid id)
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