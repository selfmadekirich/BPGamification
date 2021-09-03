using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual User User { get; set; }
    }
}
