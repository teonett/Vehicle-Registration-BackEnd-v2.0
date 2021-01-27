using BE_Vehicle_Control.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Commands
{
    
    [TestClass]
    public class CreateBrandCommandTests
    {
        [TestMethod]
        public void  WhenTryIncludeNewBrandInvalid()
        {
            var command = new CreateBrandCommand("");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void  WhenTryIncludeNewBrandValid()
        {
            var command = new CreateBrandCommand("ZZZ");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}