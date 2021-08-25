using System;

namespace ChatA.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get;}

        public BaseEntity()
        {
            Created = DateTime.Now;
        }
    }
}
