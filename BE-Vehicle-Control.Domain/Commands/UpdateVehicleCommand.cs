using System;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BE_Vehicle_Control.Domain.Commands
{
    public class UpdateVehicleCommand : Notifiable, ICommand
    {
        public UpdateVehicleCommand()
        {
            
        }

        public UpdateVehicleCommand(Guid id, string description, int yearBuild, int yearModel, Guid vehicleModelId)
        {
            Id = id;
            Description = description;
            YearBuild = yearBuild;
            YearModel = yearModel;
            VehicleModelId = vehicleModelId;
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int YearBuild { get; set; }
        public int YearModel { get; set; }
        public Guid VehicleModelId { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Description, 2, "Description", "The Category field must contain between 2 and 20 characters.")
                .HasMaxLen(Description, 20, "Description", "The Category field must contain between 2 and 20 characters.")
            );
        }
    }
}