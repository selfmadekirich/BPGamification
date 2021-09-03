using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class Division
    {
        public Division()
        {
            Users = new HashSet<User>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public string City { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
