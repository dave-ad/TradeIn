namespace Ad.TradeIn.AppDomain.Users;
public class UserModel
{
    // Account Information
    [Key]
    [Column(TypeName = "int")]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string FirstName { get; set; }
    
    [Column(TypeName = "nvarchar(250)")]
    public string? MiddleName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string LastName { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    [EmailAddress]
    public string Email { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string Gender { get; set; }
    public DateFormat DOB { get; set; }

    [Column(TypeName = "int")]
    public int PhoneNumber { get; set; }
    
    [PasswordPropertyText]
    public string Password { get; set; }
    
    [PasswordPropertyText]
    public string ConfirmPassword { get; set; }

    // Shipping Information
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int ZipCode { get; set; }
    public string Country { get; set; }

    // Billing Information
    public string BillingAddress { get; set; }
    [CreditCard]
    public string CardDetails { get; set; }

    // Order History
    public int OrderId { get; set; }
    public string OrderDetails { get; set; }      
}
