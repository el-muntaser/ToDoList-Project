using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.Data;
using ToDoListDAL.Entity;
using ToDoListDTOs;

namespace ToDoListDAL.DataRepo.UserRepo
{
    public class UserManage : IUserManage
    {
        private AppDbContext _appDbContext;

        public UserManage(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User?> AddUser(User user)
        {
            try
            {

               
                await _appDbContext.Users.AddAsync(user);
                await  _appDbContext.SaveChangesAsync();
                return user;

            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return null;
            }
            
        }

        public async Task<int> CounterUser()
        {
            return await _appDbContext.Users.CountAsync();
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);

            if (user == null)
                return false; 

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<ShowUserDto>> GetAllUser()
        {
            var Users = await  _appDbContext.Users.Select(u => new ShowUserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Phone = u.Phone
            }).ToListAsync();

            return Users;
        }

        public async Task<User?> GetUserByPhone(string Phone)
        {
             return await _appDbContext.Users.SingleOrDefaultAsync(u => u.Phone == Phone);

        }

        public async Task<bool> IsExistsUser(int id)
        {
            return await _appDbContext.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<User?> UpdateUser(User user)
        {
            var existingUser = await _appDbContext.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Phone = user.Phone;

            await _appDbContext.SaveChangesAsync();
            return existingUser;

        }
    }
}
