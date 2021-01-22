using System;
using System.Collections.Generic;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;

namespace BE_Vehicle_Control.Test.Mocks
{
    public class FakeBrandRepository : IBrandRepository
    {
        
        public IEnumerable<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand GetById(Guid id)
        {
            return new Brand("ZZZ");
        }

        public void Add(Brand entity)
        {
            
        }

        public void Update(Brand entity)
        {
            
        }
        public void Remove(Brand entity)
        {
            
        }
    }
}