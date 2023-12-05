//using Ad.TradeIn.AppDomain.Users.Auth;
//using Ad.TradeIn.Commons.DTO;
//using MediatR;
//using Microsoft.AspNetCore.Identity;

//namespace Ad.TradeIn.AppCore.Users.Auth;

//public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseDTO>>
//{
//    private readonly UserManager<UserModel> _userManager;
//    private readonly SignInManager<UserModel> _signInManager;

//    public LoginCommandHandler(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
//    {
//        _userManager = userManager;
//        _signInManager = signInManager;
//    }
//    //public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
//    //{
//    //    var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, lockoutOnFailure: false);

//    //    if (result.Succeeded)
//    //    {
//    //        return Result.Success();
//    //    }

//    //    return Result.Failure("Invalid login attempt.");
//    //}
//    public async Task<Result<LoginResponseDTO>> Handle(LoginCommand request, CancellationToken cancellationToken)
//    {
//        var user = await _userManager.FindByEmailAsync(request.Email);
//        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
//        {
//            return Result<LoginResponseDTO>.Fail("Invalid email or password.");
//        }

//        var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: false);
//        if (!signInResult.Succeeded)
//        {
//            return Result<LoginResponseDTO>.Fail("Invalid email or password.");
//        }

//        // Generate and return a JWT token
//        var token = GenerateJwtToken(user);

//        return Result<LoginResponseDTO>.Success(new LoginResponseDTO
//        {
//            Token = token,
//            UserId = user.Id
//        });
//    }

//    private string GenerateJwtToken(UserModel user)
//    {
//        // Implement JWT token generation logic here
//        // ...

//        return "GeneratedToken";
//    }

//}