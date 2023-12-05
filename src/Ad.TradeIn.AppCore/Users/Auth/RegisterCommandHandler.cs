using Ad.TradeIn.Entities.Data;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ad.TradeIn.AppCore.Users.Auth;

public class RegisterCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
{
    private readonly UserManager<UserModel> _userManager;
    private readonly APIDbContext _apidbContext;
    private readonly ILogger<RegisterCommandHandler> _logger;

    public RegisterCommandHandler(UserManager<UserModel> userManager, APIDbContext apidbContext, ILogger<RegisterCommandHandler> logger)
    {
        _userManager = userManager;
        _apidbContext = apidbContext;
        _logger = logger;
    }

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.Email) ||
            string.IsNullOrWhiteSpace(request.Password) || request.Password != request.ConfirmPassword)
        {
            throw new ValidationException("Invalid user registration data");
        }

        try
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new Exception("Passwords do not match.");
            }

            //string hashedPassword = PasswordHasher.HashPassword(request.Password);

            var user = new UserModel
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Gender = request.Gender,
                //DOB = request.DOB,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Email,
                Email = request.Email,
                //Password = hashedPassword
            };

            using var transaction = await _apidbContext.Database.BeginTransactionAsync(/*cancellationToken*/);

            var result = await _userManager.CreateAsync(user, request.Password);

            //transaction.Commit();
            if (result.Succeeded)
            {
                try
                {
                    await _apidbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation($"User {user.UserName} was successfully created. User details: {JsonConvert.SerializeObject(new { user.UserName, user.FirstName, user.LastName, user.Email })}");

                    //return new UserModel
                    //{
                    //    FirstName = request.FirstName,
                    //    LastName = request.LastName,
                    //    Email = request.Email
                    //};
                    return user;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while creating a user");
                    await transaction.RollbackAsync(); // Rollback the transaction in case of an error
                    throw;
                }


                
            }
            else
            {
                _logger.LogError($"Error creating user: {string.Join(", ", result.Errors)}");
                throw new ApplicationException($"Error creating user: {String.Join(",", result.Errors)}");

            }
        }
        catch (DbUpdateException dbEx)
        {
            _logger.LogError(dbEx, "An error occurred while updating the database");
            throw new ApplicationException("Error updating the database", dbEx);
        }
        //catch (Exception ex)
        //{
        //    _logger.LogError(ex, "An error occurred while creating a user");
        //    throw;
        //}
    }
}