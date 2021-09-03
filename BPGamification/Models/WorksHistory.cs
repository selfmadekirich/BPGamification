using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class WorksHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool? Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual User User { get; set; }
    }
}
