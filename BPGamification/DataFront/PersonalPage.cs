using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPGamification.DataFront
{
    public class PersonalPage
    {
       public int dailyTask { get; set; }
        public double percent { get; set; }

        public IEnumerable<UserTask> TodayTask { get; set; }

    }
}
