using System;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BE_Vehicle_Control.Test.Entities
{
    [TestClass]
    public class VehicleModelTests
    {
        private readonly VehicleModel _validVehicleModel = new VehicleModel("ZZZ", EnumTypeVehicle.Truck, Guid.NewGuid());
        private readonly VehicleModel _invalidVehicleModel = new VehicleModel("", EnumTypeVehicle.Truck, Guid.NewGuid());
        
        [TestMethod]
        public void should_insert_new_vehicle_model_record_valid()
        {
            Assert.AreEqual(_validVehicleModel.Description, "ZZZ");
        }

        [TestMethod]
        public void should_insert_new_vehicle_model_record_invalid()
        {
            Assert.AreEqual(_invalidVehicleModel.Description, "");
        }
    }
}