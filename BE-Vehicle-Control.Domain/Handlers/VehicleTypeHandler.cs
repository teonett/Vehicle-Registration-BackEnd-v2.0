using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using BE_Vehicle_Control.Shared.Handlers.Contracts;
using Flunt.Notifications;

namespace BE_Vehicle_Control.Domain.Handlers
{
    public class VehicleTypeHandler :
        Notifiable,
        IHandler<CreateVehicleTypeCommand>,
        IHandler<UpdateVehicleTypeCommand>,
        IHandler<RemoveVehicleTypeCommand>
    {
        private readonly IVehicleTypeRepository _repository;

        public VehicleTypeHandler()
        {
            
        }

        public VehicleTypeHandler(IVehicleTypeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateVehicleTypeCommand command)
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

            var vehicleType = new VehicleType(command.Description);
            _repository.Add(vehicleType);

            return new BaseCommandResult(true, "Type saved successfully.", vehicleType);
        }

        public ICommandResult Handle(UpdateVehicleTypeCommand command)
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

            var vehicleType = _repository.GetById(command.Id);
            vehicleType.UpdateDescription(command.Description);
            _repository.Update(vehicleType);

            return new BaseCommandResult(true, "Type updated successfully.", vehicleType);
        }

        public ICommandResult Handle(RemoveVehicleTypeCommand command)
        {
            var brand = _repository.GetById(command.Id);

            if (brand == null)
            {
                return new BaseCommandResult(
                    false, 
                    "Whoops, looks like something went wrong.",
                    command.Notifications
                );
            }

            _repository.Remove(command.Id);

            return new BaseCommandResult(true, "Type removed successfully.", brand);
        }
    }
}