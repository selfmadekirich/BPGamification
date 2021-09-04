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


        Task<Purchase> IRepository.AddPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        Task<UserBage> IRepository.AddUserBadge(UserBage userBage)
        {
            throw new NotImplementedException();
        }

        Task<WorksHistory> IRepository.AddWorkHistory(WorksHistory history)
        {
            throw new NotImplementedException();
        }

        Task<Coin> IRepository.ChangeUserCoin(Coin newCoin)
        {
            throw new NotImplementedException();
        }

        Task IRepository.DeleteWorkHistory()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Coin>> IRepository.GetAllCoins()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Task>> IRepository.GetAllUserTasks(int userId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item>> IRepository.GetItems()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Coin>> IRepository.GetUserBadges()
        {
            throw new NotImplementedException();
        }

        async Task<User> IRepository.GetUserById(int userID)
        {
            return await _dataBaseContext.Users.AsNoTracking().FirstAsync(user => user.Id == userID);
        }

        Task<IEnumerable<Coin>> IRepository.GetUserCoins()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<WorksHistory>> IRepository.GetUserWorkHistory(int userID)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Task>> IRepository.GetAllTasks()
        {
            return await _dataBaseContext.Tasks.AsNoTracking().ToListAsync();
        }
    }
}
