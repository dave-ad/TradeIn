namespace Ad.TradeIn.AppCore.Authentication;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        //using SHA256 sha256 = SHA256.Create();
        //byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder builder = new();
        for (int i = 0; i < hashedBytes.Length; i++)
        {
            builder.Append(hashedBytes[i].ToString("x2"));
        }
        return builder.ToString();
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        string inputHash = HashPassword(password);
        return string.Equals(inputHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
    }
}
