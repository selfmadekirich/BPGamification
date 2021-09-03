using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class UserTask
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? TaskId { get; set; }
        public bool? Status { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
