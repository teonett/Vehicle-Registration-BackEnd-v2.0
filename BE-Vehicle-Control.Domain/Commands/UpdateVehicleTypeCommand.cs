using System;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class UpdateVehicleTypeCommand : Notifiable, ICommand
    {
        public UpdateVehicleTypeCommand()
        {
            
        }

        public UpdateVehicleTypeCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
        
        public Guid Id { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Description, 2, "Description", "The Type field must contain between 2 and 20 characters.")
                .HasMaxLen(Description, 20, "Description", "The Type field must contain between 2 and 20 characters.")                
            );
        }
    }
}