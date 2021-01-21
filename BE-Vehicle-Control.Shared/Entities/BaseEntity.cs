using System;
namespace BE_Vehicle_Control.Shared.Entities
{
    public abstract class BaseEntity
    {
        
        public Guid Id { get; private set; }
    }
}