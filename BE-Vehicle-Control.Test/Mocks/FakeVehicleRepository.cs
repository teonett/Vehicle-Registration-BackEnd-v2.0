using System;
using System.Collections.Generic;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;

namespace BE_Vehicle_Control.Test.Mocks
{
    public class FakeVehicleRepository : IVehicleRepository
    {

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(Guid id)
        {
            return new Vehicle("ZZZ", DateTime.Now.Year, DateTime.Now.Year, Guid.NewGuid());
        }
        public void Add(Vehicle entity)
        {
            
        }

        public void Update(Vehicle entity)
        {
            
        }

        public void Remove(Vehicle entity)
        {
            
        }
    }
}