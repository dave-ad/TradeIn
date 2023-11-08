namespace Ad.TradeIn.CoreApi.Controllers.Users
{
    public class CreateUserController :  BaseApiController
    {
        //private readonly IMediator _mediator;

        public CreateUserController(IMediator mediator)
        {
            //_mediator = mediator;
        }

        // POST: api/CreateUser/signup
        [HttpPost]
        [Route("signup")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SignUp([FromBody] CreateUserCommand command)
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
                // Log the exception
                return StatusCode(500, new { Error = "An error occurred while processing your request." });
            }
        }

    }
}
