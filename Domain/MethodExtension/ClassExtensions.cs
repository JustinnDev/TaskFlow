using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Domain.MethodExtension
{
    public static class ClassExtensions
    {
        public static void ThrowIfNull <TEntity>([NotNull]this TEntity entity, [CallerArgumentExpression(nameof(entity))] string paramName = "") where TEntity : class
        {
            if(entity == null)
            {
                throw new ArgumentException($"{paramName} is null");
            }
        }
    }
}
