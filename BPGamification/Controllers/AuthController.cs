using BPGamification.Infrastructure.Interfaces;
using BPGamification.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BPGamification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAutorizer _autorizer;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAutorizer autorizer, ILogger<AuthController> logger)
        {
            _autorizer = autorizer;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SingIn(UserModel userModel)
        {
            if (_autorizer.Authorization(userModel))
            {
                return Ok();
            }

            return Forbid();
        }
    }
}
