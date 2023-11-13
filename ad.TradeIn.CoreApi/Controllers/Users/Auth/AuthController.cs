using Ad.TradeIn.AppDomain.Users.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Ad.TradeIn.CoreApi.Controllers.Users.Auth
{
    public class AuthController : BaseApiController
    {
        // POST: api/CreateUser/signup
        [HttpPost]
        [Route("signup")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            try
            {
                var UserModel = Mediator.Send(command);

                if (UserModel != null)
                {
                    // Using DTO
                    //var userDto = new UserDto(userModel);

                    return Ok(new { Message = "User registered successfully" });
                }
                else
                {
                    // Handle validation errors
                    return BadRequest(new { Error = "Failed to reister user." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while processing your request." });
            }
        }

        [HttpPost("Login")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return Ok(command);
            //try
            //{
            //    var UserModel = await Mediator.Send(command);
            //    if (UserModel != null)
            //        return Unauthorized(UserModel);

            //    return Ok(UserModel);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { Error = "An error occurred while processing your request." });
            //}
        }
    }
}
