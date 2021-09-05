using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPGamification;
using Microsoft.EntityFrameworkCore;
using BPGamification.Interfaces;

namespace Bot.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly IRepository repository;

        public BotController(IRepository repo)
        {
            repository = repo;
        }

        [HttpPost]
        public async Task<ActionResult> GetWork(WorksHistory data)
        {
            try
            {  
                if (data == null)
                    return BadRequest();

                await repository.AddWorkHistory(data);
                if(data.Status==true)
                {
                    Coin cn = await repository.GetUserCoins((int)data.UserId);
                    cn.Raiting += 5;
                    await repository.ChangeUserCoin(cn);
                }
                //Проверка не выполнились ли задания..
                await CheckNTaskInRowComplete(data.UserId.Value);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database problems while getting Personal Page");
            }
        }


        //Выполнить @NeedCNT заданий под подряд без ошибок
        private async System.Threading.Tasks.Task CheckNTaskInRowComplete(int userId)
        {
            var UserTasks = await repository.GetAllUserTasks(userId);

            var history = await repository.GetUserWorkHistory(userId);

            var unperformedTaskIds = UserTasks.Where(x => !x.Status.Value).Select(x => x.TaskId.Value).ToHashSet();

            var unperformedUserTask = UserTasks.Where(x => !x.Status.Value);

            var unperforemdTasks  = await repository.GetTasksByIds(unperformedTaskIds);

            if (!unperforemdTasks.Any(x => x.TaskType.Equals("2")))
                return;

            var userHistory = repository.GetUserWorkHistory(userId);
            await UpdateNecceseryUserTasks(history, unperforemdTasks, unperformedUserTask);
        }

        private async System.Threading.Tasks.Task UpdateNecceseryUserTasks(IEnumerable<WorksHistory> histories,IEnumerable<BPGamification.Task> unperforemdTasks,IEnumerable<UserTask> userTasks)
        {
            int countPerformedTask = CountTaskPerformedInRow(histories);
            foreach (var task in userTasks)
            {
                var allTaskWithId = unperforemdTasks.Where(x => x.TaskId == task.TaskId);
                foreach (var testedTask in allTaskWithId)
                {
                    if (countPerformedTask < testedTask.NeedCnt)
                    {
                       await repository.UpdateUserTaskStatus(task.Id);
                        break;
                    }

                }
            }
        }

        

        // считаем сколько  заданий выполнено подряд без ошибок
        private int CountTaskPerformedInRow(IEnumerable<WorksHistory> histories)
        {
            return histories.OrderByDescending(x => x.EndTime).TakeWhile(x => x.Status.Value).Count();
        }

    }
}
