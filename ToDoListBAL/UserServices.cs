using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.DataRepo.UserRepo;
using ToDoListDAL.Entity;
using ToDoListDTOs;

namespace ToDoListBAL
{
    public class UserServices : IUserServices
    {
        private IUserManage _userManageRepo;

        public UserServices(IUserManage userManage)
        {
            _userManageRepo = userManage;
        }

        public string ComputeHash(string input)
        {

            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public async Task<ShowUserDto?> AddUser(AddUserDto user)
        {
            if(user == null) throw new ArgumentNullException("user");

            if(user.Phone?.Length < 9)
            {
                throw new ArgumentException("Phone IS Erorr");
            }


            try
            {
                var NewUser = new User 
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Password = ComputeHash(user.Password),
                    RoleId = user.RoleId,
                };
                 await _userManageRepo.AddUser(NewUser);

                var result = new ShowUserDto {Id = NewUser.Id, FirstName = NewUser.FirstName,LastName = NewUser.LastName,Phone = NewUser.Phone };
                return result;
            }
            catch (Exception ex) 
            {
                 Console.WriteLine(ex.ToString());
                return null;
            }


        }

        public async Task<List<ShowUserDto>> GetAllUser()
        {
            return await _userManageRepo.GetAllUser();
        }

        public async Task<ShowUserDto?> GetUserByPhone(string Phone)
        {
            var user = await _userManageRepo.GetUserByPhone(Phone);

            if(user == null) return null;

            var ShowUser = new ShowUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
            };
           return ShowUser;
        }

        public async Task<bool> DeleteUser(int Id)
        {
            if (!await _userManageRepo.IsExistsUser(Id))
            {
                return false;
            }

            await _userManageRepo.DeleteUser(Id);
            return true;
        }

        public async Task<int> CounterUser()
        {
           return await _userManageRepo.CounterUser();
           
            
        }

        public async Task<ShowUserDto?> UpdateUser(UpdateUserDto updateUserDto)
        {
            var User = new User
            {
                Id = updateUserDto.Id,
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
                Phone = updateUserDto.Phone
            };
            

             var newuser = await _userManageRepo.UpdateUser(User);

            if (newuser == null)
            {
                return null;
            }

            return new ShowUserDto { Id = newuser.Id, FirstName = newuser.FirstName, LastName = newuser.LastName,Phone = newuser.Phone };
        }
    }
}
