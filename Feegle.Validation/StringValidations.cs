namespace Feegle.Validation
{
    using System;

    public static class StringValidations
    {
        public static IValidationContext<string> StartsWith(this IValidationContext<string> validationContext, string value, StringComparison stringComparison = StringComparison.InvariantCulture)
        {
            validationContext.Validate(
                o => o.StartsWith(value, stringComparison),
                f =>
                    {
                        throw new ArgumentException(String.Format("Fields must start with '{0}' - {1}", value, f));
                    });

            return validationContext;
        }
    }
}