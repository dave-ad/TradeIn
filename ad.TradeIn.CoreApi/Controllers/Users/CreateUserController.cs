using Microsoft.AspNetCore.Mvc;

namespace Ad.TradeIn.CoreApi.Controllers.Users
{
    public class CreateUserController
    {
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
