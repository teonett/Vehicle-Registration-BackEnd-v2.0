using System;
using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class CreateVehicleModelCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewCategoryInvalid()
        {
            var command = new CreateVehicleModelCommand("",EnumTypeVehicle.Truck, Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewCategoryValid()
        {
            var command = new CreateVehicleModelCommand("ZZZ",EnumTypeVehicle.Truck, Guid.NewGuid());
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}