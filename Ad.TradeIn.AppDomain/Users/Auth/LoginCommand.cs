//using Ad.TradeIn.Commons.DTO;


namespace Ad.TradeIn.AppDomain.Users.Auth;
//public class LoginCommand : IRequest<Result<LoginResponseDTO>>
public class LoginCommand 
{
    public string Email { get; set; }
    public string Password { get; set; }

    //public LoginDTO LoginDTO { get; set; }
}
