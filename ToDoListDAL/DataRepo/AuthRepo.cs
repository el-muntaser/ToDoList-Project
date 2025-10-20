using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.Data;
using ToDoListDTOs;

namespace ToDoListDAL.DataRepo
{
    public class AuthRepo : IAuthRepo
    {
        readonly private AppDbContext _appDbContext;

        public AuthRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<AuthDto?> Auth(string Phone, string password)
        {
            try
            {

                var user = await _appDbContext.Users.Where(u => u.Phone == Phone && u.Password == password).Select(u => new AuthDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    RoleName = u.Role.RoleName
                }).SingleOrDefaultAsync();

                return user;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
            return null;



           
        }
    }
}
