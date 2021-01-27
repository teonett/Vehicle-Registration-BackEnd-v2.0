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
    [Route("v1/type")]

    public class TypeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<VehicleType> GetAll([FromServices] IVehicleTypeRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public VehicleType GetById(
            Guid Id, 
            [FromServices] IVehicleTypeRepository repository)
        {
            return repository.GetById(Id);
        }

        [Route("")]
        [HttpPost]
        public BaseCommandResult Create(
            [FromBody]CreateBrandCommand command,
            [FromServices]BrandHandler handler
        )
        {
            return (BaseCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("")]
        public BaseCommandResult Update(
            [FromBody]UpdateVehicleTypeCommand command,
            [FromServices]VehicleTypeHandler handler
        )
        {
            return (BaseCommandResult)handler.Handle(command);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public void Remove(
            Guid Id, 
            [FromServices] IVehicleTypeRepository repository)
        {
            repository.Remove(Id);
        }
    }
}