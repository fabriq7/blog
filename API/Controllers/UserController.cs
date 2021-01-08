using Application.DTO.Request;
using Application.Interfaces;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Create([FromBody] UserDTO addUserCommand)
        {
            try
            {
                var user = await _userService.Create(addUserCommand);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserAuthenticateDTO userAuthenticate)
        {
            try
            {
                var token = await _userService.Authenticate(userAuthenticate);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
