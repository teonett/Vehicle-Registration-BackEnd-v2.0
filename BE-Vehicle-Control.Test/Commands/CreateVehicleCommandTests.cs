using System;
using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class CreateVehicleCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewCategoryInvalid()
        {
            var command = new CreateVehicleCommand("", 1900, 1900, Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewCategoryValid()
        {
            var command = new CreateVehicleCommand("ZZZ", DateTime.Now.Year, DateTime.Now.Year, Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}