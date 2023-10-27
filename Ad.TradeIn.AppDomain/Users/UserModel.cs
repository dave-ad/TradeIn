namespace Ad.TradeIn.AppDomain.Users
{
    internal class UserModel
    {
        // Account Information
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateFormat DOB { get; set; }
        public int PhoneNumber { get; set; }
        
        [PasswordPropertyText]
        public string Password { get; set; }
        
        [PasswordPropertyText]
        public string ConfirmPassword { get; set; }

        // Shipping Information
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        // Billing Information
        public string BillingAddress { get; set; }
        [CreditCard]
        public string CardDetails { get; set; }

        // Order History
        public int OrderId { get; set; }
        public string OrderDetails { get; set; }      
    }
}
