using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BPGamification
{
    public partial class Task
    {
        public Task()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskInfo { get; set; }
        public string TaskType { get; set; }
        public int? Award { get; set; }
        public int? NeedCnt { get; set; }
        public double? NeedKpi { get; set; }
        public int? NeedTime { get; set; }

        [NotMapped]
        public string result { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
