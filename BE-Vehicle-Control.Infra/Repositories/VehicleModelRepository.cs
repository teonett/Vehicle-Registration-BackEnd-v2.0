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
            var vehicleModels = _context.VehicleModels
                                .Include(x => x.Brand)
                                .Include(x => x.TypeVehicle)
                                .AsNoTracking()
                                .ToList();

            return vehicleModels;
        }

        public VehicleModel GetById(Guid id)
        {
            return _context.VehicleModels
            .Include(x => x.Brand)
            .Include(x => x.TypeVehicle)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<VehicleModel> GetByBrandType(Guid brandId, Guid vehicleTypeId)
        {
            return _context.VehicleModels
            .Where(x => x.Brand.Id == brandId && x.TypeVehicle.Id == vehicleTypeId)
            .Include(x => x.Brand)
            .Include(x => x.TypeVehicle)
            .AsNoTracking();
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