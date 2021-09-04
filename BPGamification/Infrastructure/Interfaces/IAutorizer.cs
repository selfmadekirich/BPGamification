using BPGamification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPGamification.Infrastructure.Interfaces
{
    public interface IAutorizer
    {
        bool Authorization(UserModel user);
    }
}
