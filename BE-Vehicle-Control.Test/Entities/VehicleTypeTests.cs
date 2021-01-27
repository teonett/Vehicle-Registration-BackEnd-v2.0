using BE_Vehicle_Control.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Entities
{
    [TestClass]
    public class VehicleTypeTests
    {
        private readonly VehicleType _validBrand = new VehicleType("ZZZ");
        private readonly VehicleType _invalidBrad = new VehicleType("");

        [TestMethod]
        public void should_insert_new_vehicle_type_record_valid()
        {
            Assert.AreEqual(_validBrand.Description, "ZZZ");
        }

        [TestMethod]
        public void should_insert_new_vehicle_type_record_invalid()
        {
            Assert.AreEqual(_invalidBrad.Description, "");
        }
    }
}