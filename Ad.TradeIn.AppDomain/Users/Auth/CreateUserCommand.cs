namespace Ad.TradeIn.AppDomain.Users.Auth;
public class CreateUserCommand : IRequest<UserModel>
{
    //public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
