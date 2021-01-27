using System;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class UpdateVehicleModelCommand : Notifiable, ICommand
    {

        public UpdateVehicleModelCommand(Guid id, string description, Guid typeVehicleId, Guid brandId)
        {
            Id = id;
            Description = description;
            TypeVehicleId = typeVehicleId;
            BrandId = brandId;
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid TypeVehicleId { get; set; }
        
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