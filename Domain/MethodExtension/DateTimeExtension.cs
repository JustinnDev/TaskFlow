namespace Domain.MethodExtension
{
    public static class DateTimeExtension
    {
        public static bool Expired(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return false;

            return DateTime.UtcNow > dateTime.Value;
        }
    }
}
