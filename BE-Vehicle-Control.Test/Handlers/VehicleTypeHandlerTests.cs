using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Handlers;
using BE_Vehicle_Control.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Handlers
{
    [TestClass]
    public class VehicleTypeHandlerTests
    {
        private BaseCommandResult _result = new BaseCommandResult();
        private readonly CreateVehicleTypeCommand _validCommand = new CreateVehicleTypeCommand("ZZZ");
        private readonly CreateVehicleTypeCommand _invalidCommand = new CreateVehicleTypeCommand("");
        private readonly VehicleTypeHandler _handler = new VehicleTypeHandler(new FakeVehicleTypeRepository());

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