using System;
using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class UpdateVehicleModelCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewVehicleModelInvalid()
        {
            var command = new UpdateVehicleModelCommand(Guid.NewGuid(), "", Guid.NewGuid(), Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewVehicleModelValid()
        {
            var command = new UpdateVehicleModelCommand(Guid.NewGuid(), "ZZZ", Guid.NewGuid(), Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}