using System;
using System.Collections.Generic;
using System.Linq;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BE_Vehicle_Control.Infra.Repositories
{        
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationContext _context;

        public BrandRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetAll()
        {
            return _context.Brands.AsNoTracking();
        }

        public Brand GetById(Guid id)
        {
            return _context.Brands
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        }

        public void Add(Brand entity)
        {
            _context.Brands.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Brand entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Brand entity)
        {
            _context.Brands.Remove(entity);
            _context.SaveChanges();
        }
    }
}