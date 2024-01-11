namespace FluxoCaixa.Shared.Extensions
{
    public static class DateExtensions
    {
        public static DateTime ToDateTime(this DateOnly dateOnly)
        {
            return dateOnly.ToDateTime(new TimeOnly(0, 0, 0, 0));
        }
    }
}
