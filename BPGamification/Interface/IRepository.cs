using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPGamification.Interfaces
{
    public interface IRepository
    {
        //Task<IEnumerable<Task>> GetAllUserTasks(int userId);
        //  Task<IEnumerable<Items>> GetItems();
        Task<IEnumerable<Task>> TaskCheck();
    }
}
