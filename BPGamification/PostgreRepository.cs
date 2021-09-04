using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPGamification.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BPGamification
{
    public class PostgreRepository : IRepository
    {
        private readonly DatabaseContext _dataBaseContext;


        public PostgreRepository(DatabaseContext dataBase)
        {
            _dataBaseContext = dataBase;
        }

        public async Task<IEnumerable<Task>> TaskCheck()
        {
            return await _dataBaseContext.Tasks.AsNoTracking().ToListAsync();
        }
    }
}
