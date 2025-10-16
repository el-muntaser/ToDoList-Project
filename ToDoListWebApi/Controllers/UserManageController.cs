using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBAL;
using ToDoListDTOs;

namespace ToDoListWebApi.Controllers
{
    [Route("api/UserManage")]
    [ApiController]
    public class UserManageController : ControllerBase
    {
        readonly private IUserServices _userServices;

        public UserManageController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("AddNewUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShowUserDto>> AddNewUser(AddUserDto addUserDto)
        {

            var result = await _userServices.AddUser(addUserDto);

            if (result == null) return BadRequest("حدث خطأ أثناء إضافة المستخدم");

            return Ok(result);

        }

        [HttpGet("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<ShowUserDto>>> GetAllUsers()
        {
            var users = await _userServices.GetAllUser();

            if (users == null || !users.Any())
                return NoContent(); // 204

            return Ok(users); // 200
        }

        [HttpGet("GetUserByPhone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShowUserDto>> GetUserByPhone(string phone)
        {
            if (phone == null)
            {
                return BadRequest("Enter your Phone");
            }

            var user = await _userServices.GetUserByPhone(phone);

            if (user == null)
            {
                return NotFound("This phone is not Found");
            }

            return Ok(user);
        }

        [HttpDelete("DeleteUser/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteUser(int Id)
        {
            bool IsDeleted = await _userServices.DeleteUser(Id);
            if (!IsDeleted)
            {
                return NotFound();
            }
            return Ok("This user is Deleted");
        }

        [HttpGet("CountUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<int>> CounterUser()
        {
            int Users = await _userServices.CounterUser();

            if (Users == 0) 
            {
                return NoContent();
            }
            return Ok(Users);
        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShowUserDto>> UpdateUser(UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null) { return BadRequest(); }
            var User = await _userServices.UpdateUser(updateUserDto);
            if (User == null) 
            {
                return NotFound();
            }
            return Ok(User);
        }
    
    }
}
