using ToDoListDAL.Entity;
using ToDoListDTOs;

namespace ToDoListBAL
{
    public interface IUserServices
    {
        public Task<ShowUserDto?> AddUser(AddUserDto user);
        public Task<ShowUserDto?> UpdateUser(UpdateUserDto updateUserDto);
        public Task<List<ShowUserDto>> GetAllUser();
        public Task<ShowUserDto?> GetUserByPhone(string Phone);
        public Task<bool> DeleteUser(int Id);
        public Task<int> CounterUser();
    }
}
