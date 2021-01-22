using BE_Vehicle_Control.Domain.Commands;
using BE_Vehicle_Control.Domain.Handlers;
using BE_Vehicle_Control.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Handlers
{
    [TestClass]
    public class BrandHandlerTests
    {
        private BaseCommandResult _result = new BaseCommandResult();
        private readonly CreateBrandCommand _validCommand = new CreateBrandCommand("ZZZ");
        private readonly CreateBrandCommand _invalidCommand = new CreateBrandCommand("");
        private readonly BrandHandler _handler = new BrandHandler(new FakeBrandRepository());

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