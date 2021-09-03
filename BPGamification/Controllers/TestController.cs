using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPGamification;
using Microsoft.EntityFrameworkCore;

namespace BPGamification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private DatabaseContext _databaseContext;

        public TestController(DatabaseContext db)
        {
            _databaseContext = db;
        }

        [HttpGet]
        public async Task<ActionResult<Task>> test()
        {
            var sampleData = await _databaseContext.Tasks.ToListAsync();
            return Ok(sampleData);
        }

    }
}
