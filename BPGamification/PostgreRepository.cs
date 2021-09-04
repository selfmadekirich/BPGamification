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


        async Task<Purchase> IRepository.AddPurchase(Purchase purchase)
        {
          var result  =  await _dataBaseContext.Purchases.AddAsync(purchase);
            await _dataBaseContext.SaveChangesAsync();
            return result.Entity;
        }

        Task<UserBage> IRepository.AddUserBadge(UserBage userBage)
        {
            throw new NotImplementedException();
        }

        async Task<WorksHistory> IRepository.AddWorkHistory(WorksHistory history)
        {
            var result = await _dataBaseContext.WorksHistories.AddAsync(history);
            await _dataBaseContext.SaveChangesAsync();
            return result.Entity;
        }

        async Task<Coin> IRepository.ChangeUserCoin(Coin newCoin)
        {
            var oldCoin = await _dataBaseContext.Coins.FirstOrDefaultAsync(coin => coin.UserId == newCoin.UserId);

            if (oldCoin != null)
            {
                oldCoin.Coins = newCoin.Coins;
                oldCoin.Raiting = newCoin.Raiting;
                oldCoin.User = oldCoin.User;
                oldCoin.UserId = newCoin.UserId;

                await _dataBaseContext.SaveChangesAsync();

                return oldCoin;
            }

            return null;
        }

        async System.Threading.Tasks.Task IRepository.DeleteWorkHistory()
        {
            var histories =  _dataBaseContext.WorksHistories;
            if (histories != null)
            {
                _dataBaseContext.WorksHistories.RemoveRange(histories);
                await _dataBaseContext.SaveChangesAsync();
            }
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
