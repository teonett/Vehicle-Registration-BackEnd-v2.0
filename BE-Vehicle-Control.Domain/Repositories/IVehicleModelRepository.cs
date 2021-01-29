using System;
using System.Collections.Generic;
using BE_Vehicle_Control.Domain.Entities;

namespace BE_Vehicle_Control.Domain.Repositories
{
    public interface IVehicleModelRepository : IBaseRepository<VehicleModel>
    {
         IEnumerable<VehicleModel> GetByBrandType(Guid brandId, Guid vehicleTypeId);
    }
}