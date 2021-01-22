using System;
using BE_Vehicle_Control.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Entities
{
    [TestClass]
    public class BrandTests
    {
        private readonly Brand _validBrand = new Brand("ZZZ");
        private readonly Brand _invalidBrad = new Brand("");

        [TestMethod]
        public void should_insert_new_brand_record_valid()
        {
            Assert.AreEqual(_validBrand.Description, "ZZZ");
        }

        [TestMethod]
        public void should_insert_new_brand_record_invalid()
        {
            Assert.AreEqual(_invalidBrad.Description, "");
        }
    }
}