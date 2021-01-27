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
    [Route("v1/model")]
    public class ModelController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<VehicleModel> GetAll(
            [FromServices] IVehicleModelRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public VehicleModel GetById(
            Guid Id, 
            [FromServices] IVehicleModelRepository repository)
        {
            return repository.GetById(Id);
        }

        [Route("")]
        [HttpPost]
        public BaseCommandResult Create(
            [FromBody]CreateVehicleModelCommand command,
            [FromServices]VehicleModelHandler handler
        )
        {
            return (BaseCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("")]
        public BaseCommandResult Update(
            [FromBody]UpdateVehicleModelCommand command,
            [FromServices]VehicleModelHandler handler
        )
        {
            return (BaseCommandResult)handler.Handle(command);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public void Remove(
            Guid Id, 
            [FromServices] IVehicleModelRepository repository)
        {
            repository.Remove(Id);
        }
    }
}