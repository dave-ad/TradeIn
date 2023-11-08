namespace Ad.TradeIn.Entities.Data;
public class APIDbContext : DbContext
{
    public APIDbContext(DbContextOptions option) : base(option)
    {

    }

    public DbSet<UserModel> User { get; set; }
    //public object Users { get; set; }
}
