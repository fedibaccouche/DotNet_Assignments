
using System.Text.RegularExpressions;
public class Email
{
       public static bool IsValidEmail(string email)
    {
        // Regular expression for basic email validation
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Match the pattern against the email address
        Match match = Regex.Match(email, pattern);

        // Return true if the email matches the pattern, false otherwise
        return match.Success;
    }
}
