using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballProject
{
    public class Team
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid league { get; set; }

        public Team()
        {

        }
    }
}
