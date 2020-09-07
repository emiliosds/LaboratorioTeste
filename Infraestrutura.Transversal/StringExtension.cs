using System.Text.RegularExpressions;

namespace Infraestrutura.Transversal
{
    public static class StringExtension
    {
        private const string REGEX_EMAIL = @"^(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
        private const string REGEX_PASSWORD = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])[0-9a-zA-Z$*&@#]{8,}$";

        public static bool IsValidEmail(this string text)
        {
            var regex = new Regex(REGEX_EMAIL);
            return regex.IsMatch(text);
        }

        public static bool IsValidPassword(this string text)
        {
            var regex = new Regex(REGEX_PASSWORD);
            return regex.IsMatch(text);
        }
    }
}