using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace Domain.MethodExtension
{
    public static class StringExtensions
    {
        public static bool HasValue([NotNullWhen(true)] this string str) => !string.IsNullOrWhiteSpace(str); 

        public static void ThrowIfNullOrEmpty([NotNull]this string str, [CallerArgumentExpression(nameof(str))] string paramName = "")
        {
            if(!str.HasValue())
            {
                throw new ArgumentException($"The {paramName} is null or empty");
            }
        }

        public static void ThrowIfNullValueOrEmpty([NotNull] this string? str, [CallerArgumentExpression(nameof(str))] string? paramName = "")
        {
            if(str == null)
            {
                throw new ArgumentException($"The {paramName} is null");
            }

            if (!str.HasValue())
            {
                throw new ArgumentException($"The {paramName} is empty");
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

        public static void ThrowIfLimitMax(this string str, short max, [CallerArgumentExpression(nameof(str))] string paramName = "")
        {
            if(str.Trim().Count() > max)
            {
                throw new ArgumentException($"{paramName} exceeds the limit, max characters : {max}");
            }
        }

        public static void ThrowIfLimitMin(this string str, short min, [CallerArgumentExpression(nameof(str))]string paramName = "") 
        { 
            if(str.Trim().Count() < min)
            {
                throw new ArgumentException($"{paramName} under the limit, min characters : {min}");
            }
        }

        public static void ThrowIfNotExactLength(this string str, short length, [CallerArgumentExpression(nameof(str))]string paramName = "")
        {
            if(str.Trim().Count() != length)
            {
                throw new ArgumentException($"{paramName} needs exactly {length} characters");
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