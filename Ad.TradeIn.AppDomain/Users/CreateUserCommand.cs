namespace Ad.TradeIn.AppDomain.Users
{
    public class CreateUserCommand : IRequest<ValidationResult>
    {
        //public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
