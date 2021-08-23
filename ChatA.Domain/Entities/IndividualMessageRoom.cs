using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Domain.Entities
{
    class IndividualMessageRoom : MessageRoom
    {
        public User FirstUser { get; set; }
        public User SecondUser { get; set; }
    }
}
