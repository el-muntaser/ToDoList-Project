using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.Entity;
using ToDoListDTOs;

namespace ToDoListDAL.DataRepo
{
    public interface IUserManage
    {
        public Task<User?> AddUser(User user);
        public Task<User?> UpdateUser(User user);
        public Task<List<ShowUserDto>> GetAllUser();
        public Task<User?> GetUserByPhone(string Phone);
        public Task<bool> IsExistsUser(int  id);
        public Task<bool> DeleteUser(int id);
        public Task<int> CounterUser();
    }
}
