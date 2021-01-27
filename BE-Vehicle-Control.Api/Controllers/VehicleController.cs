using System;
using System.Collections.Generic;
using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Handlers;
using BE_Vehicle_Control.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BE_Vehicle_Control.Api.Controllers
{
    [ApiController]
    [Route("v1/vehicle")]
    public class VehicleController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Vehicle> GetAll(
            [FromServices] IVehicleRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public Vehicle GetById(
            Guid Id, 
            [FromServices] IVehicleRepository repository)
        {
            return repository.GetById(Id);
        }

        [Route("")]
        [HttpPost]
        public BaseCommandResult Create(
            [FromBody]CreateVehicleCommand command,
            [FromServices]VehicleHandler handler
        )
        {
            return (BaseCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("")]
        public BaseCommandResult Update(
            [FromBody]UpdateVehicleCommand command,
            [FromServices]VehicleHandler handler
        )
        {
            return (BaseCommandResult)handler.Handle(command);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public void Remove(
            Guid Id, 
            [FromServices] IVehicleRepository repository)
        {
            repository.Remove(Id);
        }
    }
}