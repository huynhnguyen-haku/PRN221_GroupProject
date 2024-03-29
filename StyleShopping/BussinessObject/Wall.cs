using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Wall
    {
        public Wall()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? PricePerSquare { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
