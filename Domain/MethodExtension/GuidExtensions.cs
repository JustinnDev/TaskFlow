using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Domain.MethodExtension
{
    public static class GuidExtensions
    {
        public static void ThrowIfNullOrEmpty([NotNull] this Guid? guid, [CallerArgumentExpression(nameof(guid))] string paramName = "")
        {
            if (guid == null)
            {
                throw new ArgumentException($"{paramName} is null");
            }

            if (guid == Guid.Empty)
            {
                throw new ArgumentException($"{paramName} is empty");
            }
        }
        public static void ThrowIfNullOrEmpty([NotNull] this Guid? guid, string msg, [CallerArgumentExpression(nameof(guid))] string paramName = "")
        {
            if (guid == null)
            {
                throw new ArgumentException(msg == "" ? $"{paramName} is null" : msg);
            }

            if (guid == Guid.Empty)
            {
                throw new ArgumentException(msg == "" ? $"{paramName} is empty" : msg);
            }
        }

        public static void ThrowIfEmpty(this Guid guid, [CallerArgumentExpression(nameof(guid))] string paramName = "")
        {
            if (guid == Guid.Empty)
            {
                throw new ArgumentException($"{paramName} is empty");
            }
        }
    }
}
