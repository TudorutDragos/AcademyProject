using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballProject
{
    class Footballer
    {
        public Guid footballerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDay { get; set; }
        public string nationality { get; set; }
        public Guid team { get; set; }
    }
}
