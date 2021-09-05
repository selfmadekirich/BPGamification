using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPGamification.Interfaces
{
    public interface IRepository
    {

        Task<IEnumerable<UserTask>> GetAllUserTasks(int userId);

        Task<IEnumerable<Item>> GetItems();

        /// <summary>
        /// получаем  Coin всех пользователей
        /// из Coin можно достать: коины и рейтинг(кол-во очков)
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Coin>> GetAllCoins();

        /// <summary>
        /// получаем Coin конкретного пользователя
        /// </summary>
        /// <returns></returns>
        Task<Coin> GetUserCoins(int userID);


        /// <summary>
        /// получаем все badges  пользователя
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Coin>> GetUserBadges();

        Task<User> GetUserById(int userID);

        Task<IEnumerable<WorksHistory>> GetUserWorkHistory(int userID);

        Task<WorksHistory> AddWorkHistory(WorksHistory history);

        Task<UserTask> UpdateUserTaskStatus(int userTaskId);

        Task<Coin> ChangeUserCoin(Coin newCoin);

        //пока забили
        Task<UserBage> AddUserBadge(UserBage userBage);

        Task<Purchase> AddPurchase(Purchase purchase);

        /// <summary>
        /// очищает таблицу WorkHistory
        /// </summary>
        /// <returns></returns>
        System.Threading.Tasks.Task DeleteWorkHistory();

        /// <summary>
        /// получаем  таски пользователя всех типов
        /// </summary>
        /// <param name="task_ids"></param>
        /// <returns></returns>
        Task<IEnumerable<Task>> GetTasksByIds(HashSet<int> task_ids);


        Task<IEnumerable<Task>> GetAllTasks();

        Task<IEnumerable<User>> GetAllUsers();

        Task<UserTask> ChangeUserTask(UserTask newUserTask);



    }
}
