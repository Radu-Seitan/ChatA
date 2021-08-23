using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Domain.Common
{
    class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get;}

        public BaseEntity()
        {
            Created = DateTime.Now;
        }
    }
}
