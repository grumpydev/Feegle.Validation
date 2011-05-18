namespace Feegle.Validation
{
    using System;

    public static class NumericValidations
    {
        public static IValidationContext<int> LessThan(this IValidationContext<int> validationContext, int value)
        {
            validationContext.Validate(
                i => i < value,
                f =>
                {
                    throw new ArgumentException(String.Format("Fields must be less than '{0}' - {1}", value, f));
                });

            return validationContext;
        }
    }
}