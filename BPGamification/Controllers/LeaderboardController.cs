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

        public double bonus { get; set; }

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

                //кол-во участников - позиция + 1 / кол-во 

                int pos = 1;
                int opersCount = opers.Count();
                opers = opers.OrderByDescending(x => x.reputation).Select(Operator => ((opersCount -(pos++) + 1)*1.0 / opersCount ,Operator))
                    .Select(x => new Operators() 
                    { itsMe = x.Operator.itsMe , bonus  = Math.Pow(x.Item1,1.7) ,
                        name = x.Operator.name , operatorId = x.Operator.operatorId ,
                        reputation = x.Operator.reputation
                    });

                return Ok(opers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database problems while getting Personal Page");
            }
        }


    }
}
