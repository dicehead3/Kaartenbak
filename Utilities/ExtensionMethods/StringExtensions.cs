using System.Text.RegularExpressions;
using Utilities.Exceptions;

namespace Utilities.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string Required(this string input, string exceptionMessage = "Required input")
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Baka(exceptionMessage);
            }
            return input;
        }

        public static string MinMaxLength(this string input, int minLength = 0, int maxLength = 9999, string exceptionMessage = "Length should be between {0} and {1}. Current length = {2}")
        {
            if (input.Length < minLength || input.Length > maxLength)
            {
                throw new Baka(string.Format(exceptionMessage, minLength, maxLength, input.Length));
            }
            return input;
        }

        public static string MinLength(this string input, int minLength, string exceptionMessage = "Minimum length = {0}; Current length = {1}")
        {
            if (input.Length < minLength)
            {
                throw new Baka(string.Format(exceptionMessage, minLength, input.Length));
            }
            return input;
        }

        public static string MaxLength(this string input, int maxLength, string exceptionMessage = "Maximum length = {0}; Current length = {1}")
        {
            if (input.Length > maxLength)
            {
                throw new Baka(string.Format(exceptionMessage, maxLength, input.Length));
            }
            return input;
        }

        public static string ValidEmailAddress(this string input)
        {
            const string exceptionMessage = "'{0}' is not a valid email address";

            var regex =
                new Regex(
                    @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum)\b",
                    RegexOptions.IgnoreCase);
            
            if (!regex.IsMatch(input))
            {
                throw new Baka(string.Format(exceptionMessage, input));
            }
            return input;
        }
    }
}
