using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.DataRepo;
using ToDoListDTOs;

namespace ToDoListBAL.Auth
{
    public class AuthServices : IAuthServices
    {
        private IAuthRepo _authRepo;

        public AuthServices(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
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
        public async Task<AuthDto?> LogIn(string Phone, string Password)
        {
            return await _authRepo.Auth(Phone, ComputeHash(Password));
        }
    }
}
