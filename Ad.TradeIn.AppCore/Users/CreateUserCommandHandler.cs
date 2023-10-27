using System.ComponentModel.DataAnnotations;

namespace Ad.TradeIn.AppCore.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ValidationResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        public Task<ValidationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                // Handle successful signup
                return Result<string>.Success("User created successfully.");
            }

            // Handle signup failure
            //return Result<string>.Fail(result.Errors.FirstOrDefault()?.Description);
        }
    }

}