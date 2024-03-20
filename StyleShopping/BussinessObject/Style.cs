using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Style
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Detail { get; set; }
        public int? PricePerSquare { get; set; }
    }
}
