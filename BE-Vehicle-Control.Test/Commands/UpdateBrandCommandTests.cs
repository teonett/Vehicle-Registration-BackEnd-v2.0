using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    [TestClass]
    public class UpdateBrandCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewCategoryInvalid()
        {
            var command = new UpdateBrandCommand("");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewCategoryValid()
        {
            var command = new UpdateBrandCommand("ZZZ");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}