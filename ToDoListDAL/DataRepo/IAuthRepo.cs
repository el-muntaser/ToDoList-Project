using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDTOs;

namespace ToDoListDAL.DataRepo
{
    public interface IAuthRepo
    {
        public Task<AuthDto> Auth(string username, string password);
    }
}
