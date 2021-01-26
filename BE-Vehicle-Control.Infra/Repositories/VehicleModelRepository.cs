using System;
using System.Collections.Generic;
using System.Linq;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BE_Vehicle_Control.Infra.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ApplicationContext _context;

        public VehicleModelRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public IEnumerable<VehicleModel> GetAll()
        {
            return _context.VehicleModels.AsNoTracking();
        }

        public VehicleModel GetById(Guid id)
        {
            return _context.VehicleModels
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        }

        public void Add(VehicleModel entity)
        {
            _context.VehicleModels.Add(entity);
            _context.SaveChanges();
        }

        public void Update(VehicleModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var entity = _context.VehicleModels.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _context.VehicleModels.Remove(entity);
            _context.SaveChanges();
        }
    }
}