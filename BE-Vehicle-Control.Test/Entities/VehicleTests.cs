using System;
using BE_Vehicle_Control.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Entities
{
    [TestClass]
    public class VehicleTests
    {
        private readonly Vehicle _validVahicle = new Vehicle("ZZZ", 1900, 1900, Guid.NewGuid());
        private readonly Vehicle _invalidVehicle = new Vehicle("", 1900, 1900, Guid.NewGuid());

        [TestMethod]
        public void should_insert_new_brand_record_valid()
        {
            Assert.AreEqual(_validVahicle.Description, "ZZZ");
        }

        [TestMethod]
        public void should_insert_new_brand_record_invalid()
        {
            Assert.AreEqual(_invalidVehicle.Description, "");
        }
    }
}