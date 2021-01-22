using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using BE_Vehicle_Control.Shared.Handlers.Contracts;
using Flunt.Notifications;

namespace BE_Vehicle_Control.Domain.Handlers
{
    public class VehicleModelHandler :
        Notifiable,
        IHandler<CreateVehicleModelCommand>,
        IHandler<UpdateVehicleModelCommand>,
        IHandler<RemoveVehicleModelCommand>
    {
        private readonly IVehicleModelRepository _repository;

        public VehicleModelHandler(IVehicleModelRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateVehicleModelCommand command)
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

            var model = new VehicleModel(command.Description, command.TypeVehicle, command.BrandId);
            _repository.Add(model);

            return new BaseCommandResult(true, "Saved successfully.", model);
        }

        public ICommandResult Handle(UpdateVehicleModelCommand command)
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

            var model = _repository.GetById(command.Id);
            model.UpdateDescription(command.Description, command.TypeVehicle, command.BrandId);
            _repository.Update(model);

            return new BaseCommandResult(true, "Saved successfully.", model);
        }

        public ICommandResult Handle(RemoveVehicleModelCommand command)
        {   
            var model = _repository.GetById(command.Id);
            if (model == null)
            {
                return new BaseCommandResult(
                    false, 
                    "Whoops, looks like something went wrong.",
                    command.Notifications
                );
            }

            _repository.Remove(model);

            return new BaseCommandResult(true, "Removed successfully.", model);
        }
    }
}