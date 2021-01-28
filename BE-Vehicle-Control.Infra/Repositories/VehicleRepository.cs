using System;
using System.Collections.Generic;
using System.Linq;
using BE_Vehicle_Control.Domain.Entities;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BE_Vehicle_Control.Infra.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationContext _context;

        public VehicleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _context
            .Vehicles
            .Include(x => x.VehicleModel)
                .ThenInclude(x => x.Brand)
            .Include(x => x.VehicleModel)
                .ThenInclude(x => x.TypeVehicle)
            .AsNoTracking();
        }

        public Vehicle GetById(Guid id)
        {
            return _context
            .Vehicles
            .Include(x => x.VehicleModel)
                .ThenInclude(x => x.Brand)
            .Include(x => x.VehicleModel)
                .ThenInclude(x => x.TypeVehicle)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        }

        public void Add(Vehicle entity)
        {
            _context.Vehicles.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Vehicle entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var entity = _context.Vehicles.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _context.Vehicles.Remove(entity);
            _context.SaveChanges();
        }

    }
}