using System;

namespace ChatA.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public BaseEntity()
        {
            Created = DateTime.Now;
        }
    }
}
