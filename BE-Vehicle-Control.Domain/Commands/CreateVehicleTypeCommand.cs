using BE_Vehicle_Control.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class CreateVehicleTypeCommand : Notifiable, ICommand
    {
        public CreateVehicleTypeCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Description, 2, "Description", "The Brand field must contain between 2 and 20 characters.")
                .HasMaxLen(Description, 20, "Description", "The Brand field must contain between 2 and 20 characters.")                
            );
        }
    }
}