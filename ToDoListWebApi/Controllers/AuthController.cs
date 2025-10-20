using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBAL.Auth;
using ToDoListBAL.jwt;
using ToDoListDTOs;

namespace ToDoListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenService _tokenService;
        private IAuthServices _authServices;

        public AuthController(IAuthServices authServices, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _authServices = authServices;
        }

        [HttpPost]
        public async Task<ActionResult<AuthDto>> Auth(string Phone, string Password)
        {
            var user = await _authServices.LogIn(Phone, Password);
            if (user == null) 
            {
                return BadRequest();
            }
            
            var Id = user.Id.ToString();

            var Token = _tokenService.GenerateToken(Id, user.RoleName,user.FirstName);

            return Ok(new { Token });
        }
    }
}
