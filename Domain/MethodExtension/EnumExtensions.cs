using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Domain.MethodExtension
{
    public static class EnumExtensions
    {
        public static void ThrowIfUndefined<TEnum>(this TEnum value, [CallerArgumentExpression(nameof(value))] string paramName = "") where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(value))
            {
                throw new ArgumentException($"The {paramName}:{value} not found. Those available are {Enum.GetNames<TEnum>().GetListToString()}");
            }
        }
        public static void ThrowIfUndefined<TEnum>(this TEnum? value, [CallerArgumentExpression(nameof(value))] string paramName = "") where TEnum : struct, Enum
        {
            if (value == null)
            {
                return;
            }

            if (!Enum.IsDefined(value.Value))
            {
                throw new ArgumentException($"The {paramName}:{value} not found. Those available are {Enum.GetNames<TEnum>().GetListToString()}");
            }
        }

        public static void ThrowIfNullOrUndefined<TEnum>([NotNull]this TEnum? value, [CallerArgumentExpression(nameof(value))] string paramName = "") where TEnum : struct, Enum
        {
            if (value == null)
            {
                throw new ArgumentException($"The {paramName} is null");
            }

            if (!Enum.IsDefined(value.Value))
            {
                throw new ArgumentException($"The {paramName}:{value} not found. Those available are {Enum.GetNames<TEnum>().GetListToString()}");
            }
        }
    }
}
