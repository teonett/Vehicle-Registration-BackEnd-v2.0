using System;
using System.Collections.Generic;
using System.Linq;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BE_Vehicle_Control.Infra.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly ApplicationContext _context;

        public VehicleTypeRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public IEnumerable<VehicleType> GetAll()
        {
            return _context.VehicleTypes.AsNoTracking();
        }

        public VehicleType GetById(Guid id)
        {
            return _context.VehicleTypes
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        }

        public void Add(VehicleType entity)
        {
            _context.VehicleTypes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(VehicleType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var vehicleType = _context.VehicleTypes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _context.VehicleTypes.Remove(vehicleType);
            _context.SaveChanges();
        }
    }
}