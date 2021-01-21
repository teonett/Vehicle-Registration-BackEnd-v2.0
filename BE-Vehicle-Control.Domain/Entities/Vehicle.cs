using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BE_Vehicle_Control.Shared.Entities;

namespace BE_Vehicle_Control.Domain.Entities
{
    [Table("Vehicle")]
    public class Vehicle : BaseEntity
    {
        public Vehicle()
        {
            
        }
        
        public Vehicle(string description, int yearBuild, int yearModel, Guid vehicleModelId)
        {
            Description = description;
            YearBuild = ValidCurrentYearBuild(yearBuild);
            YearModel = ValidRangeYearCategory(yearModel);
            VehicleModelId = vehicleModelId;
            LastUpdateDate = DateTime.Now;
        }

        [StringLength(20)]
        public string Description { get; private set; }

        [Required(ErrorMessage = "Year build is required!")]        
        public int YearBuild { get; private set; }

        [Required(ErrorMessage = "Year model is required!")]        
        public int YearModel { get; private set; }
        public DateTime LastUpdateDate { get; private set; }

        [Required(ErrorMessage = "Vehicle model is required!")]
        public Guid VehicleModelId { get; private set; }
        public VehicleModel VehicleModel { get; private set; }
        
        public void UpdateDescription(string description, int yearBuild, int yearModel, Guid vehicleModelId)
        {
            Description = description;
            YearBuild = ValidCurrentYearBuild(yearBuild);
            YearModel = ValidRangeYearCategory(yearModel);
            VehicleModelId = vehicleModelId;
            LastUpdateDate = DateTime.Now;
        }

        private int ValidCurrentYearBuild(int yearBuild)
        {
            int validYear = yearBuild;

            if (yearBuild < DateTime.Now.Year || yearBuild > DateTime.Now.Year)
                validYear = DateTime.Now.Year;

            return validYear;
        }

        private int ValidRangeYearCategory(int yearModel)
        {
            int validYear = yearModel;

            if (yearModel < DateTime.Now.Year || yearModel > DateTime.Now.Year+2)
                validYear = DateTime.Now.Year;

            return validYear;
        }
    }
}