using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaP5.Models
{
    public class TopEarners
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string department{ get; set; }
        public string grade { get; set; }
        public string JobTitle { get; set; }
        public double totalEarner { get; set; }
    }
}
