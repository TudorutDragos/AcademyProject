using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballProject
{
    class Clasament
    {
        public Guid clasamentId { get; set; }
        public Guid league { get; set; }
        public int position { get; set; }
        public Guid team { get; set; }
        public int teamWins { get; set; }
        public int teamDefeats { get; set; }
        public int teamDraws { get; set; }
        public int teamPoints { get; set; }

    }
}
