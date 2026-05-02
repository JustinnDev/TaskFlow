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
    }
}
