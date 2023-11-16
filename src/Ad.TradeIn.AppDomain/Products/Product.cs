namespace Ad.TradeIn.AppDomain.Products;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDetails { get; set; }

    // Foreign key
    public string UserId { get; set; }

    // Navigation property
    public UserModel User { get; set; }
}
