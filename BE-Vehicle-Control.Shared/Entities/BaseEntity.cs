using System;

namespace BE_Vehicle_Control.Shared.Entities
{
    public class BaseEntity : IEquatable<BaseEntity>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid(); 
        }

        public Guid Id { get; private set; }

        public bool Equals(BaseEntity other)
        {
            throw new NotImplementedException();
        }
    }
}