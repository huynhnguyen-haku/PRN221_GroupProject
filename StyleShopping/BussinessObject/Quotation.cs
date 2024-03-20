using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Quotation
    {
        public Quotation()
        {
            QuotationDetails = new HashSet<QuotationDetail>();
        }

        public int QuotationId { get; set; }
        public string? QuotationStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StyleId { get; set; }
        public int? Square { get; set; }
        public int? AccountId { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }

        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }
    }
}
