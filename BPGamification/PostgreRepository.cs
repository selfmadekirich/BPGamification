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

        async Task<IEnumerable<Coin>> IRepository.GetAllCoins()
        {
            return await _dataBaseContext.Coins.AsNoTracking().ToListAsync();
        }

        async Task<IEnumerable<UserTask>> IRepository.GetAllUserTasks(int userId)
        {
            return await _dataBaseContext.UserTasks.AsNoTracking().Where(UserTask => UserTask.UserId == userId).ToListAsync();
        }


        async Task<IEnumerable<Item>> IRepository.GetItems()
        {
            return await _dataBaseContext.Items.AsNoTracking().ToListAsync();
        }

        //TODO Later
        Task<IEnumerable<Coin>> IRepository.GetUserBadges()
        {
            throw new NotImplementedException();
        }

        async Task<User> IRepository.GetUserById(int userID)
        {
            return await _dataBaseContext.Users.AsNoTracking().FirstAsync(user => user.Id == userID);
        }

        async Task<Coin> IRepository.GetUserCoins(int userID)
        {
            return await _dataBaseContext.Coins.AsNoTracking().FirstAsync(Coin => Coin.UserId == userID);
        }

        async Task<IEnumerable<WorksHistory>> IRepository.GetUserWorkHistory(int userID)
        {
            return await _dataBaseContext.WorksHistories.AsNoTracking().Where(WorksHistory => WorksHistory.UserId == userID).ToListAsync();
        }

        async Task<IEnumerable<Task>> IRepository.GetAllTasks()
        {
            return await _dataBaseContext.Tasks.AsNoTracking().ToListAsync();
        }
    }
}
