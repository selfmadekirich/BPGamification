using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class UserBage
    {
        public int UserId { get; set; }
        public string TaskType { get; set; }
        public int? Count { get; set; }

        public virtual User User { get; set; }
    }
}
