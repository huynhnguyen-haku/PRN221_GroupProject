using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? InteriorId { get; set; }
        public int? Quantity { get; set; }

        public virtual Interior? Interior { get; set; }
        public virtual Order? Order { get; set; }
    }
}
