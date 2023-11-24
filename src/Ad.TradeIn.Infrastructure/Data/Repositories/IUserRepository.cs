namespace Ad.TradeIn.Infrastructure.Data.Repositories;

public interface IUserRepository
{
    Task<UserModel> GetByIdAsync(int userId);
    Task<UserModel> GetByEmailAsync(string email);
    Task AddAsync(UserModel user);
    Task UpdateAsync(UserModel user);
    Task DeleteAsync(int userId);
}
