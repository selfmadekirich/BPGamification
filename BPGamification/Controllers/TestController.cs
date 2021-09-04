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
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRepository repository;

        public TestController(IRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Task>> test()
        {
            return Ok(await repository.TaskCheck());
        }

    }
}
