using System.Linq;

namespace Utilities.Policies
{
    public class PasswordPolicy: IPasswordPolicy
    {
        public bool Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (password.Length < 6)
            {
                return false;
            }

            if (password.Length > 255)
            {
                return false;
            }

            if (!password.Any(char.IsLetter))
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
