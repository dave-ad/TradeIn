namespace Ad.TradeIn.AppDomain.Users.Auth;
public class CreateUserCommand : IRequest<UserModel>
{
    //public string UserId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    //public DateFormat DOB { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
