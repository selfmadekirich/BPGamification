using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPGamification.Infrastructure.Interfaces
{
    public interface IAutorizer
    {
        bool Authorization(User user);
        bool Registration(User user);
    }
}
