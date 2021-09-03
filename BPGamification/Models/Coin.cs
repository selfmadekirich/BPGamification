using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class Coin
    {
        public int UserId { get; set; }
        public int? Coins { get; set; }
        public int? Raiting { get; set; }

        public virtual User User { get; set; }
    }
}
