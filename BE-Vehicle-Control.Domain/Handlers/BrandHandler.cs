using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Shared.Commands.Contracts;
using BE_Vehicle_Control.Shared.Handlers.Contracts;
using Flunt.Notifications;

namespace BE_Vehicle_Control.Domain.Handlers
{
    public class BrandHandler :
        Notifiable,
        IHandler<CreateBrandCommand>,
        IHandler<UpdateBrandCommand>
    {
        private readonly IBrandRepository _repository;

        public BrandHandler()
        {
            
        }

        public BrandHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBrandCommand command)
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

            var brand = new Brand(command.Description);
            _repository.Add(brand);

            return new BaseCommandResult(true, "Saved successfully.", brand);
        }

        public ICommandResult Handle(UpdateBrandCommand command)
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

            var brand = new Brand(command.Description);
            _repository.Update(brand);

            return new BaseCommandResult(true, "Saved successfully.", brand);
        }
    }
}