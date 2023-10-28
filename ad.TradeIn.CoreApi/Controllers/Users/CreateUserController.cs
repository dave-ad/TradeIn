namespace Ad.TradeIn.CoreApi.Controllers.Users
{
    [Route("api/{[controler]")]
    [ApiController]
    public class CreateUserController :  ControllerBase
    {
        private readonly APIDbContext _context;

        public CreateUserController(APIDbContext context)
        {
            _context = context;
        }

        // POST: api/SignUp
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] CreateUserCommand command)
        {
            try
            {
                var validationResult = await _mediator.Send(command);

                if (validationResult.IsValid)
                {
                    return Ok(new { Message = "User registered successfully" });
                }
                else
                {
                    // Handle validation errors
                    return BadRequest(new { Errors = validationResult.Errors });
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
