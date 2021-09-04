using BPGamification.Infrastructure.Interfaces;
using BPGamification.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPGamification.Infrastructure
{
    public class Autorizer : IAutorizer
    {
        private readonly DatabaseContext _databaseContext;
        private readonly HttpContext _httpContext;
        
        public Autorizer(DatabaseContext context, IHttpContextAccessor iHttpContext)
        {
            _databaseContext = context;
            _httpContext = iHttpContext.HttpContext;
        }

        public bool Authorization(UserModel userModel)
        {
            try
            {
                var user = userModel.GetUser();

                if (!(_databaseContext.Users.FirstOrDefault(p=>p.Email == user.Email && p.PasswordHash == user.PasswordHash)is null))
                {
                    _httpContext.Response.Cookies.Delete("UserHash");
                    _httpContext.Response.Cookies.Append("UserHash", user.PasswordHash);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
