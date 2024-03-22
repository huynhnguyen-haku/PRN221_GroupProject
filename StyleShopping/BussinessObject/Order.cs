using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? UserId { get; set; }
        public string? Note { get; set; }
        public int? Status { get; set; }
        public int? StyleId { get; set; }
        public int? Square { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
