using Ad.TradeIn.AppDomain.Users.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ad.TradeIn.CoreApi.Controllers.Users.Auth
{
    public class AuthController : BaseApiController
    {

        private readonly UserManager<UserModel> _userManager;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public AuthController(UserManager<UserModel> userManager, ILogger<RegisterCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        // POST: api/CreateUser/signup
        [HttpPost]
        [Route("signup")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Error = "Invalid request data.", ValidationErrors = ModelState.Values.SelectMany(v => v.Errors) });
                }

                var UserModel = await Mediator.Send(command);

                if (UserModel != null)
                {
                    return Ok(new 
                    { 
                        Message = "User registered successfully",
                        User = UserModel
                    });
                }
                else
                {
                    // Handle validation errors
                    return BadRequest(new { Error = "Failed to reister user." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request in the auth controller log.");
                return StatusCode(500, new { Error = "An error occurred while processing your request in the auth controller." });
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

        [HttpGet]
        public async Task<IActionResult> ViewUserData()
        {
            //var users = await _userManager.Users.ToListAsync();
            //return View(users);
            return Ok();
        }
    }
}
