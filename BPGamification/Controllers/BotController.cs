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
    public class CoinShopController : ControllerBase
    {
        private readonly IRepository repository;

        public CoinShopController(IRepository repo)
        {
            repository = repo;
        }

        [HttpGet("getWork/[body]")]
        public async Task<ActionResult> GetWork(WorksHistory data)
        {
            try
            {
                await repository.AddWorkHistory(data);
                if(data.Status==true)
                {
                    Coin cn = await repository.GetUserCoins((int)data.UserId);
                    cn.Raiting += 5;
                    await repository.ChangeUserCoin(cn);
                }
                //Проверка не выполнились ли задания..
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database problems while getting Personal Page");
            }
        }


    }
}
