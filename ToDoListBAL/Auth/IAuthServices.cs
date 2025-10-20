using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDTOs;

namespace ToDoListBAL.Auth
{
    public interface IAuthServices
    {
        public Task<AuthDto?> LogIn(string Phone,string Password);
    }
}
