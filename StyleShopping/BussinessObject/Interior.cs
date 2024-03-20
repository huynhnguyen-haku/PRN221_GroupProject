using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Interior
    {
        public Interior()
        {
            OrderDetails = new HashSet<OrderDetail>();
            QuotationDetails = new HashSet<QuotationDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public string? Image { get; set; }
        public string? Detail { get; set; }
        public int? CateId { get; set; }

        public virtual Category? Cate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }
    }
}
