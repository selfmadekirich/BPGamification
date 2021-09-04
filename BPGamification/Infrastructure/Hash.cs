using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BPGamification.Infrastructure
{
    public static class Hash
    {
        public static string GetHashStringInBase64(string input)
        {
            var data = Encoding.Unicode.GetBytes(input);

            var hashProvider = new SHA256CryptoServiceProvider();

            data = hashProvider.ComputeHash(data);

            return Convert.ToBase64String(data);
        }
    }
}
