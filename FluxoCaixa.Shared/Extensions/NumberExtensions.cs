namespace FluxoCaixa.Shared.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsGreaterThanZero(this int value)
            => value > 0;

        public static bool IsGreaterThanZero(this int? value)
            => value != null && value > 0;

        public static bool IsNullOrLessThanZero(this int? value)
            => ((double?)value).IsNullOrLessThanZero();

        public static bool IsNullOrLessThanZero(this double? value)
            => value == null || value < 0;
    }
}
