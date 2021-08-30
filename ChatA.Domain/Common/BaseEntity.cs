using System;

namespace ChatA.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get;}

        public BaseEntity()
        {
            Created = DateTimeOffset.Now;
        }
    }
}
