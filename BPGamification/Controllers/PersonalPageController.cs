using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPGamification;
using Microsoft.EntityFrameworkCore;
using BPGamification.Interfaces;
using Microsoft.AspNetCore.Cors;
using BPGamification.DataFront;

namespace BPGamification.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalPageController : ControllerBase
    {
        private readonly IRepository repository;

        public PersonalPageController(IRepository repo)
        {
            repository = repo;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonalPage>> GetUserPersonalPage(int id)
        {
            try
            {
                var tasks = await repository.GetAllUserTasks(id);
                var workHistory = await repository.GetUserWorkHistory(id);

                HashSet<int> task_ids = tasks.Select(x => x.TaskId.Value).ToHashSet();

                var TaskTypeIds = await repository.GetTasksByIds(task_ids);

                tasks = tasks.Select(x => new UserTask()
                {    Id = x.Id, Status = x.Status, Task = GetCurrentProgress(TaskTypeIds.FirstOrDefault(y => x.TaskId == y.TaskId),workHistory),
                    TaskId = x.TaskId, User = x.User });


                var failedTask = workHistory.Where(w => !w.Status.Value).Count() * 1.0;

                if (workHistory.Count() != 0)
                    failedTask /= workHistory.Count();

                return Ok(new PersonalPage() {
                    dailyTask = workHistory.Count(),
                    percent = failedTask,
                    TodayTask = tasks
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database problems while getting Personal Page");
            }

        }

        // считаем сколько  заданий выполнено подряд без ошибок
        private int CountTaskPerformedInRow(IEnumerable<WorksHistory> histories)
        {
            return histories.OrderByDescending(x => x.EndTime).TakeWhile(x => x.Status.Value).Count();
        }

        // считаем сколько обработанных @NeedCNT заявок за @NeedTime было ( отсчет идет с текущего времени) 
        private int CountTaskPerformedInRowInTime(int needTime,IEnumerable<WorksHistory> histories)
        {
            return histories.OrderByDescending(x => x.EndTime).TakeWhile(x => DateTime.Now.Subtract(x.EndTime.Value).Minutes < needTime).Count();  
        }

        private Task GetInstaceOfTaskWithRecord(Task task , string result)
        {
            return new Task()
            {
                TaskId = task.TaskId,
                Award = task.Award.Value,
                result = result,
                TaskInfo = task.TaskInfo,
                TaskName = task.TaskName,
                TaskType = task.TaskType
            };
        }

        private Task GetCurrentProgress(Task task,IEnumerable<WorksHistory> histories)
        {
            
                switch (task.TaskType)
                {
                    case "1": return (GetInstaceOfTaskWithRecord(task,null));
                    case "2": 
                        {
                            int user_res = CountTaskPerformedInRow(histories);
                            return GetInstaceOfTaskWithRecord(task, user_res + "/" + task.NeedCnt);
                        }
                    case "3":
                        {
                            int user_res = CountTaskPerformedInRowInTime(task.NeedTime.Value,histories);
                            return GetInstaceOfTaskWithRecord(task, user_res + "/" + task.NeedTime.Value); 
                        }
                    case "4":
                        {
                            int user_res = histories.Where(x => x.Status.Value).Count();
                            return GetInstaceOfTaskWithRecord(task, user_res + "/" + task.NeedCnt);
                        }
                    case "5":
                        {
                            int total = histories.Count();
                            double user_res_failed = histories.Where(x => !x.Status.Value).Count() * 1.0;
                            double user_res = user_res_failed / total == 0  ? 1 : total;
                            return GetInstaceOfTaskWithRecord(task, user_res + "/" + task.NeedKpi);
                        }
                    default:break;
                }


            return new Task();
        }


    }
}
