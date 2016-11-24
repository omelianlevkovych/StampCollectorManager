using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampCollectorManager.INF.EntityFramework
{
    public class Stamp
    {
        public int Id { get; set; }

        public string Country { get; set; }
        
        public int CreationYear { get; set; }

        public int Circulation { get; set; }

        public string Features { get; set; }

        public string PhotoUrl { get; set; }

        public decimal Price { get; set; }

        public virtual StampCollector StampCollector { get; set; }
    }
}
