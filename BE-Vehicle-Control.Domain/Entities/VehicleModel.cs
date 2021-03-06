using System.ComponentModel.DataAnnotations;
using System;
using BE_Vehicle_Control.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Vehicle_Control.Domain.Entities
{
    [Table("VehicleModel")]
    public class VehicleModel : BaseEntity
    {
        public VehicleModel()
        {
            
        }

        public VehicleModel(string description, Guid typeVehicleId, Guid brandId)
        {
            Description = description.Trim().ToUpper();
            TypeVehicleId = typeVehicleId;
            BrandId = brandId;
            LastUpdateDate = DateTime.Now;
        }

        [StringLength(10)]
        [Required(ErrorMessage = "Mdel description is required!")]
        public string Description { get; private set; }
        
        [DataType(DataType.Date)]
        public DateTime LastUpdateDate { get; private set; }
        
        [Required(ErrorMessage = "Vehicle type vehicle is required!")]
        public Guid TypeVehicleId { get; private set; }
        public virtual VehicleType TypeVehicle { get; private set; }
        
        [Required(ErrorMessage = "Vehicle brand is required!")]
        public Guid BrandId { get; private set; }
        public virtual Brand Brand { get; private set; }

        public void UpdateDescription(string description, Guid typeVehicleId, Guid brandId)
        {
            Description = description.Trim().ToUpper();
            TypeVehicleId = typeVehicleId;
            BrandId = brandId;
            LastUpdateDate = DateTime.Now;
        }        
    }
}