using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BE_Vehicle_Control.Shared.Entities;

namespace BE_Vehicle_Control.Domain.Entities
{
    [Table("Brand")]
    public class Brand : BaseEntity
    {
        public Brand()
        {
            
        }

        public Brand(string description)
        {
            Description = description.Trim().ToUpper();
            LastUpdateDate = DateTime.Now;
        }

        [StringLength(20)]
        [Required(ErrorMessage = "Brand is required!")]
        public string Description { get; private set; }
        
        [DataType(DataType.Date)]
        public DateTime LastUpdateDate { get; private set; }
        
        public void UpdateDescription(string description)
        {
            Description = description.Trim().ToUpper();
            LastUpdateDate = DateTime.Now;
        }
    }
}