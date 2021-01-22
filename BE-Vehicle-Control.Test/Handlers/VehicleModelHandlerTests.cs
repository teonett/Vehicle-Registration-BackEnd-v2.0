using System;
using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Enums;
using BE_Vehicle_Control.Domain.Handlers;
using BE_Vehicle_Control.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Handlers
{
    [TestClass]
    public class VehicleModelHandlerTests
    {
        private BaseCommandResult _result = new BaseCommandResult();
        private readonly CreateVehicleModelCommand _validCommand = new CreateVehicleModelCommand("ZZZ",EnumTypeVehicle.Truck, Guid.NewGuid());
        private readonly CreateVehicleModelCommand _invalidCommand = new CreateVehicleModelCommand("",EnumTypeVehicle.Truck, Guid.NewGuid());
        private readonly VehicleModelHandler _handler = new VehicleModelHandler(new FakeVehicleModelRepository());

        [TestMethod]
        public void ShouldNotReturnErrorWhenTryInsertInvalidResgister()
        {
            _result = (BaseCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }

         [TestMethod]
        public void ShouldReturnErrorWhenTryInsertValidResgister()
        {
            _result = (BaseCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }
    }
}