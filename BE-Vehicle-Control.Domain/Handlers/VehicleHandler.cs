using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using BE_Vehicle_Control.Shared.Handlers.Contracts;
using Flunt.Notifications;

namespace BE_Vehicle_Control.Domain.Handlers
{
    public class VehicleHandler :
        Notifiable,
        IHandler<CreateVehicleCommand>,
        IHandler<UpdateVehicleCommand>
    {

        private readonly IVehicleRepository _repository;

        public VehicleHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateVehicleCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new BaseCommandResult(
                    false, 
                    "Whoops, looks like something went wrong.",
                    command.Notifications
                );
            }

            var vehicle = new Vehicle(command.Description, command.YearBuild, command.YearModel, command.VehicleModelId);
            _repository.Add(vehicle);

            return new BaseCommandResult(true, "Saved successfully.", vehicle);
        }

        public ICommandResult Handle(UpdateVehicleCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new BaseCommandResult(
                    false, 
                    "Whoops, looks like something went wrong.",
                    command.Notifications
                );
            }

            var vehicle = new Vehicle(command.Description, command.YearBuild, command.YearModel, command.VehicleModelId);
            _repository.Update(vehicle);

            return new BaseCommandResult(true, "Saved successfully.", vehicle);
        }
    }
}