using System;
using System.Collections.Generic;

#nullable disable

namespace BPGamification
{
    public partial class User
    {
        public User()
        {
            Purchases = new HashSet<Purchase>();
            UserTasks = new HashSet<UserTask>();
            WorksHistories = new HashSet<WorksHistory>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public int? DivisionCode { get; set; }

        public virtual Division DivisionCodeNavigation { get; set; }
        public virtual Coin Coin { get; set; }
        public virtual UserBage UserBage { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
        public virtual ICollection<WorksHistory> WorksHistories { get; set; }
    }
}
