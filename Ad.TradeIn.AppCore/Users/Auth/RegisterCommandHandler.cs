using Ad.TradeIn.AppDomain.Users.Auth;

namespace Ad.TradeIn.AppCore.Users.Auth;

public class RegisterCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            throw new Exception("Passwords do not match.");
        }

        string hashedPassword = PasswordHasher.HashPassword(request.Password);

        var user = new UserModel
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = hashedPassword
        };

        // Add user to the database through repository
        await _userRepository.AddAsync(user);

        return user;

        //var userDto = new UserDto(user);
        //return userDto;
    }
}