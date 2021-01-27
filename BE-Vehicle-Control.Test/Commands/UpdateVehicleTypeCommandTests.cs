using System;
using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class UpdateVehicleTypeCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewVehicleTypeInvalid()
        {
            var command = new UpdateVehicleTypeCommand(Guid.NewGuid(), "");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewVehicleTypeValid()
        {
            var command = new UpdateVehicleTypeCommand(Guid.NewGuid(), "CAR");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}