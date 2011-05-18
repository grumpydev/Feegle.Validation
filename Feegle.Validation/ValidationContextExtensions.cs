namespace Feegle.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ValidationContextExtensions
    {
        public static IEnumerable<string> GetFailingFields<T>(this IValidationContext<T> validationContext, Func<T, bool> validator)
        {
            return validationContext.ValidationTargets.Where(c => !validator(c.PropertyValue))
                                                      .Select(t => t.PropertyDelegate.GetParameterName())
                                                      .ToArray();
        }

        public static void Validate<T>(this IValidationContext<T> validationContext, Func<T, bool> validator, Action<string> onFail, Action onSuccess = null)
        {
            var failing = validationContext.GetFailingFields(validator);

            if (failing.Any())
            {
                onFail.Invoke(failing.Aggregate((s1, s2) => s1 + ", " + s2));
            }
            
            if (onSuccess != null)
            {
                onSuccess.Invoke();
            }
        }
    }
}