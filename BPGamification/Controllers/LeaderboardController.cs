using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPGamification;
using Microsoft.EntityFrameworkCore;
using BPGamification.Interfaces;

namespace LeaderboardController.Controllers
{
    public class Operators
    {
        public string name { get; set; }
        public int reputation { get; set; }

        public bool itsMe { get; set; }

        public int operatorId { get; set; }
        public Operators(string nm, int id, bool its)
        {

            name = nm;
            operatorId = id;
            itsMe = its;
        }
        public Operators()
        {

        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly IRepository repository;

        public LeaderboardController(IRepository repo)
        {
            repository = repo;
        }

        [HttpGet("getleaders/{id:int}")]
        public async Task<ActionResult<IEnumerable<Operators>>> GetUsersLeaderboard(int id)
        {
            try
            {
                var users = await repository.GetAllUsers();
                IEnumerable<Operators> opers = users.Select(user => new Operators(user.FullName, user.Id, user.Id == id)).ToList();
                foreach(var op in opers)
                {
                    var Coin = await repository.GetUserCoins(op.operatorId);
                    op.reputation = (int)Coin.Raiting;
                }
                var t = opers.First();
                return Ok(opers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database problems while getting Personal Page");
            }
        }


    }
}
