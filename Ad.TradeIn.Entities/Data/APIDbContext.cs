namespace Ad.TradeIn.Entities.Data;
//public class APIDbContext : DbContext
public class APIDbContext : IdentityDbContext<UserModel, IdentityRole, string>
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Relationships
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Products)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        // Explicit primary key definition for Order
        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

        // Explicit primary key definition for Product
        modelBuilder.Entity<Product>()
            .HasKey(p => p.ProductId);

        //modelBuilder.Entity<Order>()
        //    .HasOne(u => u.User)
        //    .WithMany(u => u.Orders)
        //    .HasForeignKey(o => o.UserId);

        //modelBuilder.Entity<Product>()
        //    .HasOne(p => p.User)
        //    .WithMany(u => u.Products)
        //    .HasForeignKey(p => p.UserId);
    }
}
