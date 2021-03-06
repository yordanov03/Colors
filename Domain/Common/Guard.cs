using Colors.Domain.Exceptions;
using System.Text.RegularExpressions;
using static Colors.Domain.Common.ModelConstants;

namespace Colors.Domain.Common
{
    public static class Guard
    {
        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null ot empty.");
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void ForValidZipcode<TException>(string zipcode, string name = "Value")
           where TException : BaseDomainException, new()
        {
            bool validZipcode;

            if (!string.IsNullOrEmpty(zipcode))
            {
                validZipcode = Regex.IsMatch(zipcode, ZipcodeRegexPattern);
                if (validZipcode)
                {
                    return;
                }
            }

            ThrowException<TException>($"{name} must be a valid zipcode.");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Message = message
            };

            throw exception;
        }
    }
}
