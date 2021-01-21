using System.ComponentModel.DataAnnotations;
using System;
using BE_Vehicle_Control.Domain.Enums;
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

        public VehicleModel(string description, EnumTypeVehicle typeVehicle, Guid brandId)
        {
            Description = description;
            TypeVehicle = typeVehicle;
            BrandId = brandId;
            LastUpdateDate = DateTime.Now;
        }

        [StringLength(10)]
        [Required(ErrorMessage = "Mdeld description is required!")]
        public string Description { get; private set; }

        [Required(ErrorMessage = "Type vehicle is required!")]
        public EnumTypeVehicle TypeVehicle { get; private set; }
        
        [DataType(DataType.Date)]
        public DateTime LastUpdateDate { get; private set; }

        [Required(ErrorMessage = "Vehicle brand is required!")]
        public Guid BrandId { get; private set; }
        public Brand Brand { get; private set; }

        public void UpdateDescription(string description, EnumTypeVehicle typeVehicle, Guid brandId)
        {
            Description = description;
            TypeVehicle = typeVehicle;
            BrandId = brandId;
            LastUpdateDate = DateTime.Now;
        }        
    }
}