using System;
using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class UpdateVehicleCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewVehicleInvalid()
        {
            var command = new UpdateVehicleCommand(Guid.NewGuid(), "", 1900, 1900, Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewVehicleValid()
        {
            var command = new UpdateVehicleCommand(Guid.NewGuid(), "ZZZ", DateTime.Now.Year, DateTime.Now.Year, Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}