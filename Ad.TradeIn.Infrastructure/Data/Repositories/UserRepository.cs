﻿namespace Ad.TradeIn.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly APIDbContext _context;

    public UserRepository(APIDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel> GetByIdAsync(int userId)
    {
        return await _context.User.FindAsync(userId);
    }

    public async Task<UserModel> GetByEmailAsync(string email)
    {
        return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(UserModel user)
    {
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserModel user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int userId)
    {
        var user = await _context.User.FindAsync(userId);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
