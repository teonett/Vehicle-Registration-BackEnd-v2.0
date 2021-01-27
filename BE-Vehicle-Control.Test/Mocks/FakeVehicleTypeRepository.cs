using System;
using System.Collections.Generic;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;

namespace BE_Vehicle_Control.Test.Mocks
{
    public class FakeVehicleTypeRepository : IVehicleTypeRepository
    {
        
        public IEnumerable<VehicleType> GetAll()
        {
            throw new NotImplementedException();
        }

        public VehicleType GetById(Guid id)
        {
            return new VehicleType("ZZZ");
        }

        public void Add(VehicleType entity)
        {
            
        }

        public void Update(VehicleType entity)
        {
            
        }

        public void Remove(Guid id)
        {
            
        }
    }
}