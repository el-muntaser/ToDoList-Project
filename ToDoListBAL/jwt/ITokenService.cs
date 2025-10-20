using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBAL.jwt
{
    public interface ITokenService
    {
        public string GenerateToken(string userId, string RoleName, string firstName);
    }
}
