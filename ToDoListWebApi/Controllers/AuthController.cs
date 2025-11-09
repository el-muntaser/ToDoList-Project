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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<ActionResult<AuthDto>> Auth([FromBody]LoginDto loginDto)
        {
            if (loginDto is null) 
            {
                return BadRequest();
            }
            var user = await _authServices.LogIn(loginDto.Phone, loginDto.Password);

            if (user is null) 
            {
                return NotFound();
            }
            
            var Id = user.Id.ToString();

            var Token =  _tokenService.GenerateToken(Id, user.RoleName,user.FirstName);

            return Ok(new { Token });
        }
    }
}
