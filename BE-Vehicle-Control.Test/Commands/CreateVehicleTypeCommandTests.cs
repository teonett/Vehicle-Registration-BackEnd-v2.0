using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class CreateVehicleTypeCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewVehicleTypeInvalid()
        {
            var command = new CreateVehicleTypeCommand("");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewVehicleTypeValid()
        {
            var command = new CreateVehicleTypeCommand("CAR");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}