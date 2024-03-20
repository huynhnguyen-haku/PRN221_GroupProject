using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Category
    {
        public Category()
        {
            Interiors = new HashSet<Interior>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Interior> Interiors { get; set; }
    }
}
