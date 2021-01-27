using System;
using System.Collections.Generic;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;

namespace BE_Vehicle_Control.Test.Mocks
{
    public class FakeVehicleModelRepository : IVehicleModelRepository
    {
        public IEnumerable<VehicleModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public VehicleModel GetById(Guid id)
        {
            return new VehicleModel("ZZZ", Guid.NewGuid(), Guid.NewGuid());
        }

        public void Add(VehicleModel entity)
        {
            
        }

        public void Update(VehicleModel entity)
        {
            
        }
        public void Remove(Guid id)
        {
            
        }

    }
}