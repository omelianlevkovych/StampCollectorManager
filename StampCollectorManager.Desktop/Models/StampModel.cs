using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampCollectorManager.Desktop.Models
{
    class StampModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public int CreationYear { get; set; }

        public int Circulation { get; set; }

        public string Features { get; set; }

        public decimal Price { get; set; }

        public string OwnerId { get; set; }
    }
}
