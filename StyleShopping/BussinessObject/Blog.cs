using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Blog
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string? Image { get; set; }
        public string? Detail { get; set; }
        public string? Title { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }

        public virtual Account? Account { get; set; }
    }
}
