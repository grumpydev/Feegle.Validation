namespace Feegle.Validation
{
    using System;
    using System.Linq;

    public static class Validate
    {
        public static ValidationContext<T> Arguments<T>(params Func<T>[] parameters)
        {
            return new ValidationContext<T>(parameters);
        }

        public static ValidationContext<object> Arguments(params Func<object>[] parameters)
        {
            return new ValidationContext<object>(parameters);
        }
    }
}