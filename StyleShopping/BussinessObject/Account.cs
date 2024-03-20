using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public partial class Account
    {
        public Account()
        {
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
