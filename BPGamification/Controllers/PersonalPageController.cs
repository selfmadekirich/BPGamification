using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPGamification;
using Microsoft.EntityFrameworkCore;
using BPGamification.Interfaces;

namespace BPGamification.Controllers
{
    public class PersonalPage
    {

        public int dailyTask { get; set; }
        public double percent { get; set; }

        public IEnumerable<UserTask> TodayTask { get; set; }

    }


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


    }
}
