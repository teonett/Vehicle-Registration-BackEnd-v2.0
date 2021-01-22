using System;
using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Handlers;
using BE_Vehicle_Control.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Handlers
{
    [TestClass]
    public class VehicleHandlerTests
    {
        private BaseCommandResult _result = new BaseCommandResult();
        private readonly CreateVehicleCommand _validCommand = new CreateVehicleCommand("ZZZ", DateTime.Now.Year, DateTime.Now.Year, Guid.NewGuid());
        private readonly CreateVehicleCommand _invalidCommand = new CreateVehicleCommand("", 1900, 1900, Guid.NewGuid());
        private readonly VehicleHandler _handler = new VehicleHandler(new FakeVehicleRepository());

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