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

        async Task<UserTask> IRepository.ChangeUserTask(UserTask newUserTask)
        {
            var oldUserTask = await _dataBaseContext.UserTasks.FirstOrDefaultAsync(userTask => userTask.Id == newUserTask.Id);

            if (oldUserTask != null)
            {
                oldUserTask.Id = newUserTask.Id;
                oldUserTask.TaskId = newUserTask.TaskId;
                oldUserTask.Status = newUserTask.Status;
                oldUserTask.UserId = newUserTask.UserId;

                await _dataBaseContext.SaveChangesAsync();

                return oldUserTask;
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

        async  Task<IEnumerable<Task>> IRepository.GetTasksByIds(HashSet<int> task_ids)
        {
            return await _dataBaseContext.Tasks.AsNoTracking().Where(x => task_ids.Contains(x.TaskId)).ToListAsync();
        }

        async Task<IEnumerable<Task>> IRepository.GetAllTasks()
        {
            return await _dataBaseContext.Tasks.AsNoTracking().ToListAsync();
        }

        async Task<IEnumerable<User>> IRepository.GetAllUsers()
        {
            return await _dataBaseContext.Users.AsNoTracking().ToListAsync();
        }
    }
}
