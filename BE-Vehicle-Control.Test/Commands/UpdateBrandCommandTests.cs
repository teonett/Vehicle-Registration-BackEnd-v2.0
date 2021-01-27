using System;
using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class UpdateBrandCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewBrandInvalid()
        {
            var command = new UpdateBrandCommand(Guid.NewGuid(), "");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewBrandValid()
        {
            var command = new UpdateBrandCommand(Guid.NewGuid(), "ZZZ");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}