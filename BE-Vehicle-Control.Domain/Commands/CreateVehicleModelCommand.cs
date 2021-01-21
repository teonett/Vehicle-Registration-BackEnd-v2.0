using System;
using BE_Vehicle_Control.Domain.Enums;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class CreateVehicleModelCommand : Notifiable, ICommand
    {

        public CreateVehicleModelCommand(string description, EnumTypeVehicle typeVehicle, Guid brandId)
        {
            Description = description;
            TypeVehicle = typeVehicle;
            BrandId = brandId;
        }

        public string Description { get; set; }

        public EnumTypeVehicle TypeVehicle { get; set; }
        
        public Guid BrandId { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Description, 2, "Description", "The Model field must contain between 2 and 10 characters.")
                .HasMaxLen(Description, 10, "Description", "The Model field must contain between 2 and 10 characters.")                
            );
        }
    }
}