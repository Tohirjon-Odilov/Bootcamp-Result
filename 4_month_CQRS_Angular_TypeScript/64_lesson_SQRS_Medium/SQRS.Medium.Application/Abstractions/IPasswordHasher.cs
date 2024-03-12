using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Medium.Application.Abstractions
{
    public interface IPasswordHasher
    {
        public string Encrypt(string password, string salt);
        public bool Verify(string hash, string password, string salt);
    }
}
