using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace Domain.MethodExtension
{
    public static class StringExtensions
    {
        public static bool HasValue([NotNullWhen(true)] this string str) => !string.IsNullOrWhiteSpace(str); 

        public static void ThrowIfNullOrEmpty([NotNull]this string str, [CallerArgumentExpression(nameof(str))] string name = "")
        {
            if(!str.HasValue())
            {
                throw new ArgumentException($"The {name} is null or empty");
            }
        }

        public static void ThrowIfNotValidEmail(this string email, [CallerArgumentExpression(nameof(email))] string paramName = "")
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new ArgumentException($"{paramName} invalid format");
            }    
        }

        public static void ThrowIfNotClearString(this string str, [CallerArgumentExpression(nameof(str))] string paramName = "")
        {
            string @params = @"[^a-zA-Z0-9_.-]";
            
            if (Regex.IsMatch(str, @params))
            {
                throw new ArgumentException($"{paramName} have invalid characters");
            }
        }

        public static void ThrowIfLimitExceeded(this string str, short limit, [CallerArgumentExpression(nameof(str))] string paramName = "")
        {
            if(str.Trim().Count() > limit)
            {
                throw new ArgumentException($"{paramName} exceeds the limit, max characters : {limit}");
            }
        }

        public static string GetListToString(this string[] list, string separator = ", ")
        {
            var listToString = "";

            for (int i = 0; i < list.Length; i++)
            {
                var newValue = $"{list[i]}{separator}";

                if (i == list.Length - 1)
                    newValue = $"{list[i]}";

                listToString += newValue;
            }

            return listToString;
        }
    }
}