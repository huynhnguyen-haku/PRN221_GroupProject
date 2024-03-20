using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Project
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Detail { get; set; }
        public string? Information { get; set; }
        public string? Result { get; set; }
        public string? Location { get; set; }
        public int? Area { get; set; }
        public int? CompleteYear { get; set; }
        public int? Value { get; set; }
    }
}
