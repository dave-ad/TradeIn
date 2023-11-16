//using Ad.TradeIn.AppDomain.Users.Auth;
//using Ad.TradeIn.Commons.DTO;
//using MediatR;
//using Microsoft.AspNetCore.Identity;

//namespace Ad.TradeIn.AppCore.Users.Auth;

//public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseDTO>>
//{
//    private readonly UserManager<ApplicationUser> _userManager;
//    private readonly SignInManager<UserModel> _signInManager;

//    public LoginCommandHandler(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
//    {
//        _userManager = userManager;
//        _signInManager = signInManager;
//    }
//    public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
//    {
//        var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, lockoutOnFailure: false);

//        if (result.Succeeded)
//        {
//            return Result.Success();
//        }

//        return Result.Failure("Invalid login attempt.");
//    }
//}