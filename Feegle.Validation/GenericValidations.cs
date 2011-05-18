using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feegle.Validation
{
    public static class GenericValidations
    {
        public static IValidationContext<T> NotNull<T>(this IValidationContext<T> validationContext)
            where T : class
        {
            validationContext.Validate(
                s => s != null,
                f =>
                {
                    throw new ArgumentNullException(f);
                });

            return validationContext;
        }
    }
}
