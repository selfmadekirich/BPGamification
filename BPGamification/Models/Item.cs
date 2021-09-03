using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class Item
    {
        public Item()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public int? Count { get; set; }
        public string Info { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
