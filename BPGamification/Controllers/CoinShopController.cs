using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPGamification;
using Microsoft.EntityFrameworkCore;
using BPGamification.Interfaces;

namespace CoinShopController.Controllers
{
    public class Showcase
    {
        public IEnumerable<Item> ListItems { get; set; }

    }


    [Route("api/[controller]")]
    [ApiController]
    public class CoinShopController : ControllerBase
    {
        private readonly IRepository repository;

        public CoinShopController(IRepository repo)
        {
            repository = repo;
        }

        [HttpGet("getshop")]
        public async Task<ActionResult<Showcase>> GetUserPersonalPage()
        {
            try
            {

                return Ok(new Showcase()
                {
                    ListItems = await repository.GetItems()
                }) ;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "database problems while getting Personal Page");
            }
        }


    }
}
