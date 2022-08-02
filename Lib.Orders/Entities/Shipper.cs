using System;
using System.Collections.Generic;

namespace Lib.Orders.Entities
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public short ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
