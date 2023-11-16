namespace Ad.TradeIn.Common.DTO;
public class UserDto : UserModel
{
    //private UserModel user;
    //public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    // Include any other non-sensitive properties you want to expose

    public UserDto(UserModel user)
    {
        //UserId = userModel.UserId;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        // Map other properties from UserModel to UserDto if needed
    }
}
