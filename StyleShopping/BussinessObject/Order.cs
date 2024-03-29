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
        public int? TypeHouseId { get; set; }
        public int? BackgroundId { get; set; }
        public int? WallId { get; set; }
        public int? CeilId { get; set; }
        public int? Height { get; set; }
        public int? Long { get; set; }
        public int? Width { get; set; }

        public virtual Background? Background { get; set; }
        public virtual CeilingHouse? Ceil { get; set; }
        public virtual Style? Style { get; set; }
        public virtual TypeHouse? TypeHouse { get; set; }
        public virtual Account? User { get; set; }
        public virtual Wall? Wall { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
