namespace Ad.TradeIn.AppDomain.Orders;
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public string OrderDetails { get; set; }
    //public object Orders { get; set; }
    // Foreign key
    public string UserId { get; set; }

    // Navigation property
    public UserModel User { get; set; }
}
